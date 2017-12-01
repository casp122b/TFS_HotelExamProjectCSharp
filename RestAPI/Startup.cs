using System;
using System.Text;
using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSingleton(Configuration);
            services.AddScoped<BLLFacade>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Jwt";
                options.DefaultChallengeScheme = "Jwt";
            }).AddJwtBearer("Jwt", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "the audience you want to validate",
                    ValidateIssuer = false,
                    //ValidIssuer = "the isser you want to validate",

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BOErgeOsTSpiser AErter 123 STK I ALT!")),

                    ValidateLifetime = true, //validate the expiration and not before values in the token

                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env, BLLFacade facade)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                //Add a DB stuff
                // facade.GuestService.Create(new GuestBO() { FirstName = "Bongo", LastName = "Bingo" });
                // facade.GuestService.Create(new GuestBO() { FirstName = "Drinky", LastName = "MacSnurf" });
                //facade.UserService.Create(new UserBO() { Username = "lbilde", Password = "shh" });
                // facade.UserService.Create(new UserBO() { Username = "dinko", Password = "aha" });
                //var facade = new BLLFacade();

                var guest1 = facade.GuestService.Create(
                    new GuestBO()
                    {
                        FirstName = "Hans",
                        LastName = "Madsen",
                        Address = "Spangsbjergvej 13"
                    });

                var guest2 = facade.GuestService.Create(
                    new GuestBO()
                    {
                        FirstName = "Line",
                        LastName = "Høj",
                        Address = "Lundgade 3"
                    });

                var singleRoom1 = facade.SingleRoomService.Create(
                    new SingleRoomBO()
                    {
                        Price = 10.1,
                        Available = 8,
                        GuestId = guest1.Id
                    });



                var suite2 = facade.SuiteService.Create(
                    new SuiteBO()
                    {
                        Price = 15.5,
                        Available = 4,
                        GuestId = guest2.Id
                    });


                var doubleRoom1 = facade.DoubleRoomService.Create(
                    new DoubleRoomBO()
                    {
                        Price = 12.5,
                        Available = 5,
                        GuestId = guest1.Id
                    });

                var booking1 = facade.BookingService.Create(
                    new BookingBO()
                    {
                        CheckIn = DateTime.Now.AddDays(-1),
                        CheckOut = DateTime.Now.AddDays(1),
                        SingleRoomId = singleRoom1.Id
                    });

                //var guest3 = facade.GuestService.Create(
                //    new GuestBO()
                //    {
                //        FirstName = "Hans",
                //        LastName = "Madsen",
                //        Address = "Spangsbjergvej 13",
                //        BookingIds = new List<int>() { booking1.Id }
                //    });
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
