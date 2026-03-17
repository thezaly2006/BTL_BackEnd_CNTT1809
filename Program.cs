using GymManagement.Data;
using GymManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. CẤU HÌNH DATABASE
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. CẤU HÌNH IDENTITY
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// 3. CẤU HÌNH AUTHORIZATION
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("StaffOrAdmin", policy => policy.RequireRole("Staff", "Admin"));
});

// Add Razor Pages (CHO IDENTITY)
builder.Services.AddRazorPages();

// 4. CẤU HÌNH MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 5. PIPELINE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// =============================================
// TẠO ROLES VÀ USERS MẪU
// =============================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // 1. Tạo Roles
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        Console.WriteLine("✓ Da tao role: Admin");
    }

    if (!await roleManager.RoleExistsAsync("Staff"))
    {
        await roleManager.CreateAsync(new IdentityRole("Staff"));
        Console.WriteLine("✓ Da tao role: Staff");
    }

    // 2. Tạo Admin User
    var adminEmail = "admin@gymmanagement.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);

    if (adminUser == null)
    {
        var newAdmin = new IdentityUser
        {
            UserName = "admin",
            Email = adminEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(newAdmin, "Admin@123");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdmin, "Admin");
            Console.WriteLine("✓ Da tao Admin: admin@gymmanagement.com / Admin@123");
        }
    }

    // 3. Tạo Staff User
    var staffEmail = "staff@gymmanagement.com";
    var staffUser = await userManager.FindByEmailAsync(staffEmail);

    if (staffUser == null)
    {
        var newStaff = new IdentityUser
        {
            UserName = "staff",
            Email = staffEmail,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(newStaff, "Staff@123");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newStaff, "Staff");
            Console.WriteLine("✓ Da tao Staff: staff@gymmanagement.com / Staff@123");
        }
    }
}
app.Run();