
using mBay_Business.Repository;
using mBay_Business.Repository.IRepository;
using mBay_DataAccsess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//path
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //bu yoktu
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddCors(x => x.AddPolicy("mBay", builder =>//cors baðlantýsý
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("mBay");


app.UseAuthorization();

app.MapControllers();

app.Run();
