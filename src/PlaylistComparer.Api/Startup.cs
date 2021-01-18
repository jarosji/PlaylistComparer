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
using Owin.Security.Providers.Spotify;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpotifyAPI.Web.Scopes;
using PlaylistComparer.Api.Utils;

namespace PlaylistComparer
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
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "basicOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000").AllowAnyHeader()
                                      .WithMethods("PUT", "POST", "PATCH", "GET", "DELETE", "OPTIONS").AllowCredentials();
                                  });
            });

            //services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator("c8bc902470624f89bb3a70aab0fedc0b", "9f96b0c0d4d0425cb5166bccd6189e30")));
            services.AddTransient<SpotifyClientBuilder>();
            services.AddSingleton<SpotifyParser>();
            services.AddSingleton<SpotifyToken>();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("spotify", policy =>
            //    {
            //        policy.AuthenticationSchemes.Add("spotify");
            //        //policy.RequireAuthenticatedUser();
            //    });
            //});
            services
              .AddAuthentication(options =>
              {
                  options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
              })
              .AddCookie(options =>
              {
                  
              });

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("basicOrigins");

            app.UseWebSockets();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // We will be using the new routing API to host our GraphQL middleware.
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
