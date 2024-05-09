using lab3.Pages;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPortfolioService>(
    new PortfolioService(
        portfolioPath: "portfolio.json",
        servicePath: "services.json",
        testimonialsPath: "testimonials.json"
    )
);

builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<TestimonialsDbContext>(
    new TestimonialsDbContext()
);

// ��������� � ���������� ������� Razor Pages
builder.Services.AddRazorPages(options =>
{
    // ��������� ��������� Antiforgery-�����
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
}); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
