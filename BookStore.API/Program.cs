using BookStore.API.Common.Mappers;
using BookStore.Application.Books.Commands.Common;
using BookStore.Application.Books.Queries.GetAllBooks;
using BookStore.Application.Metrics;
using BookStore.Data.Extensions;
using BookStore.Connectors.OpenLibrary.Extensions;
using Prometheus;
using BookStore.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookStoreMetrics>(); //register BookStore custom metrics
builder.Services.AddTransient<IOpenLibraryService, OpenLibraryService>();

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
builder.Services.AddOpenLibraryGateway(builder.Configuration);

var app = builder.Build();

app.UseMetricServer(); //default metrics set up by prometheus-net(navigate to /metrics)

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
