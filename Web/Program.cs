using BlazorHrFaq.Database.Infrastructure;
using HrFaq.Database.Infrastructure;
using Service;
using BlazorHrFaq.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddSingleton<ILoggningService, LoggningService>();
builder.Services.AddSingleton<IFaqService, FaqService>();
builder.Services.AddSingleton<ICommands, Commands>();
builder.Services.AddSingleton<ISettingsService, SettingsService>();


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
