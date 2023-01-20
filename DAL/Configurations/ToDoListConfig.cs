namespace DAL.Configurations
{
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class ToDoListConfig : IEntityTypeConfiguration<ToDoList>
	{
		public void Configure(EntityTypeBuilder<ToDoList> builder)
		{
			builder.Property(tag => tag.Name).IsRequired();
			builder.Property(tag => tag.Name).HasMaxLength(50);

			builder.HasOne(t => t.Category)
				   .WithMany(c => c.ToDoLists)
				   .HasForeignKey(t => t.CategoryId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
