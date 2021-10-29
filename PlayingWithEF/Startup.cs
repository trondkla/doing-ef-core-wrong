using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PlayingWithEF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = 

            services.AddDbContext<ApiContext>(opt =>
                //opt.UseSqlServer(Configuration.GetConnectionString("TestDb")));
                opt.UseInMemoryDatabase("test-problems-with-ef"));


            var apiContext = services.BuildServiceProvider().GetService<ApiContext>();
            AddTestData(apiContext);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private static void AddTestData(ApiContext context)
        {
            var testUser1 = new User
            {
                Id = 123,
            };

            context.Users.Add(testUser1);

            var testPost1 = new Post
            {
                Id = 567,
                UserId = testUser1.Id,
                Content = "What a piece of junk!"
            };

            context.Posts.Add(testPost1);
            context.SaveChanges();
        }

    }
}
