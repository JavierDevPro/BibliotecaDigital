// using BibliotecaDigital.Models;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace BibliotecaDigital.Data.Configuration;
//
//
// public class AuthorConfiguration : IEntityTypeConfiguration<Author>
// {
//     public void Configure(EntityTypeBuilder<Author> builder)
//     {
//         builder.HasKey(a => a.IdAuthor);
//         builder.Property(a => a.IdAuthor)
//             .IsRequired()
//             .HasMaxLength(25);
//     }
// }