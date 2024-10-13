using Booking_System.Data;
using Booking_System.Repositories.BookingRepository;
using Booking_System.Repositories.ResourceRepository;
using Booking_System.Services.BookingService;
using Booking_System.Services.ResourceService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookingSystemContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

// Register services
builder.Services.AddScoped<IResourceRepository, ResourceRepositoryImp>();
builder.Services.AddScoped<IResourceService,ResourceService>();
builder.Services.AddScoped<IBookingRepository, BookingRepositoryImp>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
