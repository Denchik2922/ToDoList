namespace DAL
{
	using DAL.Configurations;
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class ToDoListContext : DbContext
	{
		public ToDoListContext(DbContextOptions options): base(options) { }

		public DbSet<Category> Categories { get; set; }
		public DbSet<ToDoItem> ToDoItems { get; set; }
		public DbSet<ToDoList> ToDoLists { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new CategoryConfig());
			modelBuilder.ApplyConfiguration(new ToDoItemConfig());
			modelBuilder.ApplyConfiguration(new ToDoListConfig());
		}
	}
}
