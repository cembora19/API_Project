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
                new Book { Id = 1,CategoryId=1, Title = "Aklından Bir Sayı Tut", Price = 58 },
                new Book { Id = 2,CategoryId=1, Title = "Gözlerini Sımsıkı Kapat", Price = 25 },
                new Book { Id = 3,CategoryId=1, Title = "Şeytanı Uyandırma", Price = 19 },
                new Book { Id = 4,CategoryId=1, Title = "Peter Pan Ölmeli", Price = 60 },
                new Book { Id = 5,CategoryId=1, Title = "Kurt Gölü", Price = 41 },
                new Book { Id = 6,CategoryId=1, Title = "Fırtınada Yanacaksın", Price = 22 },
                new Book { Id = 7,CategoryId=1, Title = "Tepenin Laneti", Price = 13 },
                new Book { Id = 8,CategoryId=1, Title = "Yılan Avı", Price = 28 },
                new Book { Id = 9,CategoryId=1, Title = "ForUpdate", Price = 55 }
                
            );
        }
    }
}