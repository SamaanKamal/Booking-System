using Booking_System.Repositories.BookingRepository;
using Booking_System.Repositories.ResourceRepository;
using Booking_System.Services.BookingService;
using Booking_System.Services.ResourceService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

// Register services
builder.Services.AddScoped<IResourceRepository, ResourceRepositoryImp>();
builder.Services.AddScoped<IResourceService,ResourceService>();
builder.Services.AddScoped<IBookingRepository, BookingRepositoryImp>();
builder.Services.AddScoped<IBookingService, BookingService>();


var app = builder.Build();

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
