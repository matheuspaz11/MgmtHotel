
using MgmtHotel.Application.Interfaces;
using MgmtHotel.Application.Mappings;
using MgmtHotel.Application.Services;
using MgmtHotel.Domain.Interfaces;
using MgmtHotel.Persistence.Context;
using MgmtHotel.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApiMgmtHotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer")));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

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
        }
    }
}
