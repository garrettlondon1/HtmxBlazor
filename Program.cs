using HtmxDotnet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddAntiforgery();
builder.Services.AddSingleton<Database>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAntiforgery();
app.MapRazorComponents<App>();

app.MapAnnotationEndpoints();

app.Run();
