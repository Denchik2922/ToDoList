namespace DAL.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Models;

	public class ToDoItemConfig : IEntityTypeConfiguration<ToDoItem>
	{
		public void Configure(EntityTypeBuilder<ToDoItem> builder)
		{
			builder.Property(tag => tag.Name).IsRequired();
			builder.Property(tag => tag.Name).HasMaxLength(50);

			builder.HasOne<ToDoList>(t => t.ToDoList)
				   .WithMany(t => t.ToDoItems)
				   .HasForeignKey(t => t.ToDoListId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
