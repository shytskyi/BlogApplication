using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace BlogApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IGetBlog, AuthorRepository>();
            builder.Services.AddScoped<IGetBlog, TagRepository>();

            builder.Services.AddScoped<IRepository<Author>, AuthorRepository>();
            builder.Services.AddScoped<IRepository<Blog>, BlogRepository>();
            builder.Services.AddScoped<IRepository<Review>, ReviewRepository>();
            builder.Services.AddScoped<IRepository<Tag>, TagRepository>();

            builder.Services.AddScoped<IService<Author>, AuthorService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();

            builder.Services.AddScoped<IBlogService<Blog>, BlogService>();
            builder.Services.AddScoped<IService<Blog>, BlogService>();

            builder.Services.AddScoped<IService<Review>, ReviewService>();

            builder.Services.AddScoped<IService<Tag>, TagService>();
            builder.Services.AddScoped<ITagService, TagService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"), b => b.MigrationsAssembly("BlogApplication"));
            });

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