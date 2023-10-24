namespace ToDoList
{
    using BLL.ControlOfTransactions;
    using BLL.Repositories;
    using BLL.Repositories.Interfaces;
    using BLL.Services;
    using BLL.Services.Interfaces;
    using DAL;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.OpenApi.Models;

	public class Startup
	{
		public string DBConnectionString { get; }
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			if(Configuration["ConnectionString:ToDoListDB"] == null)
			{
				throw new NullReferenceException("ConnectionString is null!");
			}

			this.DBConnectionString = Configuration["ConnectionString:ToDoListDB"];
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ToDoListContext>(opts => opts.UseSqlServer(DBConnectionString));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IToDoListService, ToDoListService>();
            services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoList", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoList v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
