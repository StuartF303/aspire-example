using gwdae.web.Components;
using gwdae.web.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using gwdae.grpcservice;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHttpForwarderWithServiceDiscovery();

builder.Services.AddSingleton<DataSourceServiceClient>()
    .AddGrpcServiceReference<DataSource.DataSourceClient>("http://grpcservice", failureStatus: HealthStatus.Degraded);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
