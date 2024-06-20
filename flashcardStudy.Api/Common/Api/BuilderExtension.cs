using flascardStudy.Core;
using flascardStudy.Core.Handler;
using flashcardStudy.Api.Data;
using flashcardStudy.Api.Handlers;
using Microsoft.EntityFrameworkCore;

namespace flashcardStudy.Api.Common.Api
{
    public static class BuilderExtension
    {
        public static void  AddConfiguration (this WebApplicationBuilder builder)
        {
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( x => x.CustomSchemaIds(type => type.FullName));
        }

        public static void AddDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(o => o.UseMySQL(ApiConfiguration.ConnectionString));
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            options.AddPolicy(
                ApiConfiguration.CorsPolicyName, policy =>
                policy.WithOrigins([
                    Configuration.BackendUrl,
                    Configuration.FrontendUrl 
                ])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                ));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IDeckHandler, DeckHandler>();
            builder.Services.AddTransient<IFlashCardHandler, FlashCardHandler>();
        }
    }
}
