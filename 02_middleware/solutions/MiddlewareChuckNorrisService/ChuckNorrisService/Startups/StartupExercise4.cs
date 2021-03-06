﻿using ChuckNorrisService.Models;
using ChuckNorrisService.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChuckNorrisService.Startups
{
    public class StartupExercise4
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Dies fügt die von der Routing-Middleware benötigten
            // Dienste zum Dependency Injection Container hinzu.
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            FileSystemJokeProvider jokeProvider = new FileSystemJokeProvider();

            // Hier wird die Routing Middleware eingehängt
            // Alle nachfolgenden Middlewares erhalten Zugriff auf Informationen über die ausgewählte Route
            app.UseRouting();

            // Definition der verfügbaren Endpunkte unseres Webservices. Dies wird auch als Endpoint-Routing bezeichnet.
            // Endpunkte haben Zugriff auf die Routing-Pipeline und können somit an Features wie Authorization und Authentication teilnehmen.
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGet("api/jokes/random", async context =>
                {
                    await context.Response.WriteAsJsonAsync(await jokeProvider.GetRandomJokeAsync());
                });

                endpoints.MapGet("{*path}", context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return context.Response.WriteAsync("Well, IT'S YOUR FAULT!");
                });
            });
        }
    }
}
