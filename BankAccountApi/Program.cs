using Microsoft.EntityFrameworkCore;
using BankAccountApi.Data;
using BankAccountApi.Services;
using BankAccountApi.Services.Interfaces;
using BankAccountApi.Utils.Mapper;
using Microsoft.AspNetCore.Authentication;

namespace BankAccountApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BankContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IBankRepository, BankRepository>();
            builder.Services.AddTransient<IBankWorker, TransactionWorker>();

            builder.Services.AddAutoMapper(typeof(BankMapperProfile));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BankContext>();

                db.Database.Migrate();
            }


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}