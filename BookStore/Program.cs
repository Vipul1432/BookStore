
using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Interfaces;
using BookStore.ErrorHandler;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContextPool<BookstoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("bookStoreDbEntities"));
            });

            //Add Dependency
            builder.Services.AddScoped<IBookRepository, BookRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();

            // Exception Handler
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}