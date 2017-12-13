using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Collections.Generic;

namespace RestAPI
{
    public class Startup
    {

        public IConfiguration Configuration
        {
            get;
        }
        public IHostingEnvironment Environment2
        {
            get;
        }
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Environment2 = env;
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment2.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment2.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

        }



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
            services.AddScoped<IBLLFacade, BLLFacade>();
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
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IBLLFacade facade)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                Console.WriteLine("Solsort");
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                //Add a DB stuff
                //facade.GuestService.Create(new GuestBO() { FirstName = "Bongo", LastName = "Bingo", Address = "halm 5" });
                //facade.GuestService.Create(new GuestBO() { FirstName = "Drinky", LastName = "MacSnurf", Address = "halm 9" });

                //var user1 = facade.UserService.Create(new UserBO() { Username = "lbilde", Password = "shh", Role = "Administrator" });
                //var user2 = facade.UserService.Create(new UserBO() { Username = "dinko", Password = "aha", Role = "" });
                //facade.GuestService.Create(new GuestBO() { FirstName = "Bongo", LastName = "Bingo" });
                // facade.GuestService.Create(new GuestBO() { FirstName = "Drinky", LastName = "MacSnurf" });
                //facade.UserService.Create(new UserBO() { Username = "fgjfj", Password = "fhjjghj" });
                //facade.UserService.Create(new UserBO() { Username = "dinko", Password = "aha" });

                facade.UserService.Create(new UserBO() { Username = "wwww", Password = "aaa", Role = "Administrator" });

                //facade.AdminService.Create(new AdminBO() { FirstName = "wtwy", LastName = "Is", Address = "dsdjjd" });


                //var facade = new BLLFacade();

                var guest1 = facade.GuestService.Create(
                    new GuestBO()
                    {
                        FirstName = "Hans",
                        LastName = "Madsen",
                        Address = "Spangsbjergvej 13",
                    });

                var doubleRoom1 = facade.DoubleRoomService.Create(
                    new DoubleRoomBO()
                    {
                        Price = 12.5,
                        Available = 5,
                        GuestId = guest1.Id
                    });

                var suite2 = facade.SuiteService.Create(
                    new SuiteBO()
                    {
                        Price = 15.5,
                        Available = 4,
                        GuestId = guest1.Id
                    });

                var singleRoom13 = facade.SingleRoomService.Create(
                    new SingleRoomBO()
                    {
                        Price = 22.1,
                        Available = 8,
                        GuestId = guest1.Id
                    });


                var booking1 = facade.BookingService.Create(
                    new BookingBO()
                    {
                        CheckIn = DateTime.Now.AddDays(-1),
                        CheckOut = DateTime.Now.AddDays(1),
                        SingleRoomId = singleRoom13.Id,
                        DoubleRoomId = doubleRoom1.Id,
                        SuiteId = suite2.Id,
                        GuestId = guest1.Id
                    });

                var guest2 = facade.GuestService.Create(
                    new GuestBO()
                    {
                        FirstName = "Line",
                        LastName = "Høj",
                        Address = "Lundgade 3",
                    });

                var singleRoom1 = facade.SingleRoomService.Create(
                    new SingleRoomBO()
                    {
                        Price = 10.1,
                        Available = 8,
                        GuestId = guest1.Id
                    });
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
