using AdmonRequest.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace AdmonRequest.WebUI.ServiceInstaller
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<AppDbContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection"),
                         sqlServerOptionsAction: sqlOptions =>
                         {
                             sqlOptions.EnableRetryOnFailure(
                                 maxRetryCount: 10,
                                 maxRetryDelay: TimeSpan.FromSeconds(30),
                                 errorNumbersToAdd: null
                                 );
                         }));

            //builder.Services.AddIdentity<UserAccount, Group>()
            //                .AddDefaultTokenProviders();

            //builder.Services.AddTransient<IUserStore<UserAccount>, AdmonUserStore>();
            //builder.Services.AddTransient<IRoleStore<Group>, AdmonRoleStore>();
           // var connectionString = builder.Configuration.GetConnectionString("AppConnection");
            //builder.Services.AddTransient<SqlConnection>(e => new SqlConnection(connectionString));
           // builder.Services.AddTransient<AuthenticationService>();


           


        }
    }
}
