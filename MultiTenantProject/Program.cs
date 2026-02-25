using Microsoft.EntityFrameworkCore;
using MultiTenantProject.BLL;
using MultiTenantProject.Core;
using MultiTenantProject.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ITenantProvider, TenantProvider>();
builder.Services.AddScoped<IMultiTenantService,MultiTenantService>();
builder.Services.AddScoped<IInvoiceService,InvoiceService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TenantDb"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Tenants.AddRange(
        new() { Id = 1, Name = "LogisticsCorp" },
        new() { Id = 2, Name = "RetailGroup" }
    );
    context.SaveChanges();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();