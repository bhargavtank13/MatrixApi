using Matrix.DBContext;
using Matrix.Engine.Class;
using Matrix.Engine.Interface;
using Matrix.Mapping;
using Matrix.Repository;
using Matrix.Repository.Class;
using Matrix.Repository.Interface;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMemoryCache();

builder.Services.AddTransient<IPromptService, PromptService>();

builder.Services.AddDbContext<MatrixDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Matrix")));

//Mapper
builder.Services.AddAutoMapper(typeof(CustomerMapping));

//Customer
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<ICustomerEngine,CustomerEngine>();

//Regional Sales Director
builder.Services.AddScoped<IRegionalSaleDirectorService, RegionalSaleDirectorService>();
builder.Services.AddScoped<IRegionalSaleDirectorEngine,RegionalSalesDirectorEngine>();

//Sales Rep
builder.Services.AddScoped<ISalesRepEngine, SalesRepEngine>();
builder.Services.AddScoped<ISalesRepService, SalesRepService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
