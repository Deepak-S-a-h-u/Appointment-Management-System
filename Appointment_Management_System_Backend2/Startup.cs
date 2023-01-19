using Appointment_Management_System_Backend2.Data;
using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Appointment_Management_System_Backend2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer().
            AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("conStr"),
            b => b.MigrationsAssembly("Appointment_Management_System_Backend2")));

            services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
            services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
            services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();
            services.AddTransient<RoleManager<ApplicationRole>, ApplicationRoleManager>();
            services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
          //  services.AddTransient<IUserService, UserServices>();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserStore<ApplicationUserStore>()
            .AddUserManager<ApplicationUserManager>()
            .AddRoleManager<ApplicationRoleManager>()
            .AddSignInManager<ApplicationSignInManager>()
            .AddRoleStore<ApplicationRoleStore>()
            .AddDefaultTokenProviders();
            services.AddScoped<ApplicationRoleStore>();
            services.AddScoped<ApplicationUserStore>();
            //  services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();


            //add JWT Authentication
            var appSettingSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingSection);

            var appSetting = appSettingSection.Get<AppSetting>();
            var key = System.Text.Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddCookie()
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Appointment_Management_System_Backend2", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Appointment_Management_System_Backend2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
