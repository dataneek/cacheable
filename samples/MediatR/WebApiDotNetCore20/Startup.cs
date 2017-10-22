namespace WebApiDotNetCore20
{
    using System;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using StructureMap;
    using Swashbuckle.AspNetCore.Swagger;
    using WebApiDotNetCore20.Models;
    using Cacheable;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMediatR(typeof(Startup).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<Startup>(); 
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>)); 
                });

                config.For<IResultBuilder>().Use<ResultBuilder>().Singleton();

                config.For(typeof(IRequestHandler<,>)).DecorateAllWith(typeof(MemoryCacheRequestHandler<,>));
                config.For(typeof(IAsyncRequestHandler<,>)).DecorateAllWith(typeof(MemoryCacheAsyncRequestHandler<,>), 
                    (t) => t.ReturnedType.IsAssignableFrom(typeof(ICacheableRequestHandler)));

                config.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                config.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));

                config.For<IMediator>().Use<Mediator>();

                config.For<IMemoryCache>().Use(() => new MemoryCache(Options.Create(new MemoryCacheOptions()))).Singleton();

                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });

            app.UseMvc();
        }
    }
}