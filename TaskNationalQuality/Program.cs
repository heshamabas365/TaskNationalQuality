using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using Microsoft.EntityFrameworkCore;
using TaskNationalQuality.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;  // Make the session cookie HttpOnly
    options.Cookie.IsEssential = true;  // Make the session cookie essential
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set the session timeout duration
});


builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddDevExpressControls();
builder.Services.AddAuthorization();  // إضافة Authorization
builder.Services.AddAuthentication(); // تأكد من أنك قد أضفت Authentication إذا كنت تستخدمه



builder.Services.ConfigureReportingServices(configurator =>
{
    configurator.DisableCheckForCustomControllers();
});

var app = builder.Build();


// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseAuthentication();  // إضافة Authentication أولاً إذا كان لديك توثيق
app.UseAuthorization();   // ثم Authorization بعد ذلك
app.UseDevExpressControls();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();  // Place session after routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();


