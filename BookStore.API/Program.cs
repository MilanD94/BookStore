using BookStore.API.Common.Mappers;
using BookStore.Application.Books.Commands.Common;
using BookStore.Application.Books.Queries.GetAllBooks;
using BookStore.Application.Metrics;
using BookStore.Data.Extensions;
using OpenTelemetry.Metrics;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<BookStoreMetrics>();

builder.Services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddPrometheusExporter();

        builder.AddMeter("Microsoft.AspNetCore.Hosting",
                         "Microsoft.AspNetCore.Server.Kestrel");
        builder.AddView("http.server.request.duration",
            new ExplicitBucketHistogramConfiguration
            {
                Boundaries = [ 0, 0.005, 0.01, 0.025, 0.05,
                       0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ]
            });
    });

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ReportApiVersions = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllBooksQuery).Assembly));

builder.Services.AddServiceDataLayer(builder.Configuration);

builder.Services.AddAutoMapper(typeof(BookProfileMapper));
builder.Services.AddAutoMapper(typeof(BooksProfileMapper));

var app = builder.Build();

app.MapPrometheusScrapingEndpoint();

app.UseMetricServer();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseHttpMetrics(options =>
{
    options.AddCustomLabel("host", context => context.Request.Host.Host);
});

app.UseAuthorization();

app.MapControllers();

app.Run();
