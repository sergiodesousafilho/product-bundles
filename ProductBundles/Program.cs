using ProductBundles.Infrastructure;
using ProductBundles.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();

ConfigDependencyServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapControllerRoute(
    name: "default",    
    pattern: "{controller=home}/{action=index}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


app.Run();


void ConfigDependencyServices(IServiceCollection services)
{
    services.AddTransient<HomeService, HomeService>();
    services.AddTransient<BundleService, BundleService>();
    services.AddTransient<ProductService, ProductService>();    
    services.AddTransient<ProductBundlesDbContext, ProductBundlesDbContext>();
}