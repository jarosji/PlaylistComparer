using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using PlaylistComparer.Api;
using PlaylistComparer.Api.Schema;
using PlaylistComparer.Schema;
using SpotifyAPI.Web;
using Microsoft.Owin.Security.OAuth;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpotifyAPI.Web.Scopes;
using PlaylistComparer.Api.Utils;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Net.Http;

namespace PlaylistComparer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "basicOrigins",
                                  builder =>
                                  {
                                      builder
                                      .WithOrigins("https://localhost:3000")
                                      .AllowAnyHeader()
                                      .WithMethods("PUT", "POST", "PATCH", "GET", "DELETE", "OPTIONS")
                                      .AllowCredentials();
                                  });
            });
            services.AddSingleton<HttpClient>();
            //services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton(SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30")));
            services.AddTransient<SpotifyClientBuilder>();
            services.AddSingleton<SpotifyParser>();
            services.AddSingleton<SpotifyToken>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Spotify";
            })
                .AddCookie()
                .AddOAuth("Spotify", options =>
                {
                    options.ClientId = "c8bc902470624f89bb3a70aab0fedc0b";
                    options.ClientSecret = "9f96b0c0d4d0425cb5166bccd6189e30";
                    options.CallbackPath = new PathString("/graphql");

                    options.AuthorizationEndpoint = "https://accounts.spotify.com/authorize";
                    options.TokenEndpoint = "https://accounts.spotify.com/api/token";

                    options.SaveTokens = true;

                    var scopes = new List<string>
                    {
                        Scopes.PlaylistModifyPublic
                    };
                    options.Scope.Add(string.Join(",", scopes));
                });

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCookiePolicy();
            app.UseCors("basicOrigins");

            app.UseWebSockets();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/graphql");
                    return Task.CompletedTask;
                });
            });
        }
    }
}
