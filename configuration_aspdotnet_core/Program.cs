using Configuation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<TotalUsers>();

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "defult",
    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();
