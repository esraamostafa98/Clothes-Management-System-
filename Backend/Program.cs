using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication6.BL.Interfaces;
using WebApplication6.BL.Mapper;
using WebApplication6.BL.Repository;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<DbContainer>(opts =>
opts.UseSqlServer(
builder.Configuration.GetConnectionString("SharpDbConnection")
));

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBoundaryLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));


builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DbContainer>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);


builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 0;
});


builder.Services.AddScoped<IDepartment, DepartmentRep>();
builder.Services.AddScoped<IEmployee, EmployeeRep>();
builder.Services.AddScoped<IProduct, ProductRep>();
builder.Services.AddScoped<IFiles, FilesRep>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


builder.Services.AddCors();

var app = builder.Build();




app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseCors(options => options
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.MapGet("/", () => "Hello World!");

app.Run();
