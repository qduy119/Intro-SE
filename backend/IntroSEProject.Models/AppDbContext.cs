using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using System.Diagnostics.Contracts;

namespace IntroSEProject.Models
{

    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //loai bo tien to AspNet
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName != null && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.Entity<CategoryItem>().HasKey(x => new { x.ItemId, x.CategoryId });

            builder.Entity<OrderItem>().HasOne<Item>(x => x.Item)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ItemId);
            builder.Entity<OrderItem>().HasOne<Order>(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);

            //seed data here
            //seed data for user table
            Randomizer.Seed = new Random(8675390);
            var Gender = new[] { "Male", "Female" };
            var userId = 1;
            var userDataFaker = new Faker<AppUser>()
                //.StrictMode(true)
                .RuleFor(u => u.Id, f => (userId++).ToString())
                .RuleFor(u => u.Gender, f =>
                {
                    var index = f.Random.Number(0, 1);
                    return Gender[index];
                })
                .RuleFor(u => u.FullName, (f, u) => f.Name.FirstName() + " " + f.Name.LastName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FullName))
                .RuleFor(u => u.Avatar, (f, u) => f.Internet.Avatar())
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past())
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FullName))
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .FinishWith((f, u) => System.Console.WriteLine("User was created successfully with id = ", u.Id));


            builder.Entity<AppUser>()
                .HasData(userDataFaker.GenerateBetween(10, 10));
            //seed data item table 
            var itemId = 1;
            var dataItemFaker = new Faker<Item>()
                .RuleFor(i => i.Id, f => itemId++)
                .RuleFor(i => i.Thumbnail, f => f.Image.PicsumUrl())
                .RuleFor(i => i.Name, f => f.Lorem.Sentence(3))
                .RuleFor(i => i.Description, f => f.Lorem.Sentence(20))
                .RuleFor(i => i.Price, f => f.Random.Decimal() + 10)
                .RuleFor(i => i.Discount, f => f.Random.Decimal() + 10)
                .RuleFor(i => i.Stock, f => f.Random.Int(1, 10))
                .FinishWith((f, i) => System.Console.WriteLine("Item was create success fully"));
            builder.Entity<Item>()
                .HasData(dataItemFaker.GenerateBetween(100, 100));
            //seed data category
            var categoryId = 1;
            var dataCategoryFaker = new Faker<Category>()
                .RuleFor(c => c.Id, f => categoryId++)
                .RuleFor(c => c.Thumbnail, f => f.Image.PicsumUrl())
                .RuleFor(c => c.Name, f => f.Lorem.Sentence(3))
                .RuleFor(c => c.Description, f => f.Lorem.Paragraph(1))
                .FinishWith((f, c) => System.Console.WriteLine("Successfully"));
            builder.Entity<Category>()
                .HasData(dataCategoryFaker.GenerateBetween(10, 10));
            //seed data for categoryItem
            var idItem = 1;
            var dataCategoryItem = new Faker<CategoryItem>()
                .RuleFor(c => c.ItemId, f => idItem++)
                .RuleFor(c => c.CategoryId, f => f.Random.Int(1, 10))
                .FinishWith((f, c) => System.Console.WriteLine("successfully"));
            builder.Entity<CategoryItem>()
                .HasData(dataCategoryItem.GenerateBetween(100, 100));
            //seed data for 
        }

        public DbSet<Item> Item { set; get; }
        public DbSet<CartItem> CartItem { set; get; }
        public DbSet<Category> Category { set; get; }  
        public DbSet<Image> Image { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<OrderItem> OrderItem { set; get; }
        public DbSet<Review> Review { set; get; }
        public DbSet<AppUser> User { set; get; }
        public DbSet<Payment> Payment { set; get; }
        public DbSet<CategoryItem> CategoryItem { set; get; }
    }
}