namespace DAL.Configurations
{
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class CategoryConfig : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(tag => tag.Name).IsRequired();
			builder.Property(tag => tag.Name).HasMaxLength(50);

			builder.HasData(
			 new Category
			 {
				 Id = 1,
				 Name = "Book"
			 },
			 new Category
			 {
				 Id = 2,
				 Name = "Game"
			 },
			 new Category
			 {
				 Id = 3,
				 Name = "Movie"
			 });
		}
	}
}
