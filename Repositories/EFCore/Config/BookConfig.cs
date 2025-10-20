using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Aklından Bir Sayı Tut", Price = 58 },
                new Book { Id = 2, Title = "Gözlerini Sımsıkı Kapat", Price = 25 },
                new Book { Id = 3, Title = "Şeytanı Uyandırma", Price = 19 },
                new Book { Id = 4, Title = "Peter Pan Ölmeli", Price = 60 },
                new Book { Id = 5, Title = "Kurt Gölü", Price = 41 },
                new Book { Id = 6, Title = "Fırtınada Yanacaksın", Price = 22 },
                new Book { Id = 7, Title = "Tepenin Laneti", Price = 13 },
                new Book { Id = 8, Title = "Yılan Avı", Price = 28 },
                new Book { Id = 9, Title = "ForUpdate", Price = 55 }
                
            );
        }
    }
}