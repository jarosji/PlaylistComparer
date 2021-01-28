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
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpotifyAPI.Web.Scopes;
using System.Net.Http;
using PlaylistComparer.Api.Factories;
using PlaylistComparer.StreamingServices;
using PlaylistComparer.Api.Schema.Playlist;
using PlaylistComparer.Api.Schema.Track;

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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Spotify";
            })
                .AddCookie()
                .AddOAuth("Spotify", options =>
                {
                    options.ClientId = Configuration["Spotify:ClientId"];
                    options.ClientSecret = Configuration["Spotify:ClientSecret"];
                    options.CallbackPath = new PathString("/graphql");

                    options.AuthorizationEndpoint = "https://accounts.spotify.com/authorize";
                    options.TokenEndpoint = "https://accounts.spotify.com/api/token";

                    options.SaveTokens = true;

                    var scopes = new List<string>
                    {
                        Scopes.PlaylistModifyPublic, Scopes.UserTopRead
                    };
                    options.Scope.Add(string.Join(",", scopes));
                });

            

            services.AddSpotifyServices();

            services.AddGraphQLServer()
                .AddQueryType(x => x.Name("RootQuery"))
                    .AddTypeExtension<PlaylistQueries>()
                    .AddTypeExtension<TrackQueries>()
                .AddMutationType(x => x.Name("RootMutation"))
                    .AddTypeExtension<PlaylistMutations>()

                .AddType<PlaylistType>()

                .AddType<PlaylistInputType>();

            services.AddTransient<StreamingServicesFactory>();
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
                    context.Response.Redirect("/graphql/");
                    return Task.CompletedTask;
                });
            });
        }
    }
}
