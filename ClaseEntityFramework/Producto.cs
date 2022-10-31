using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace ClaseEntityFramework
{
    public class Client
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
    }
    public class ProductCategory
    {

        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public bool Active { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
    public class Order
    {

        public int Id { get; set; }
        public DateTime Register { get; set; }

        public Client Client { get; set; }

        public List<OrderDetail> Details { get; set; }
    }

    public class OrderDetail
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal SubTotal { get; set; }

        public Product Product { get; set; }

    }

    public class EjemploDBContext : DbContext, IUnitOfWork
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public string DbPath { get; set; }



        public EjemploDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "ejemplo.entity.framework.v2.db");
        }



        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*   modelBuilder.Entity<Product>(b =>
              {
                  b.ToTable("PRODUCTOS");
                  b.HasKey(x => x.Id);
                  b.Property(x => x.Id).IsRequired();
                  b.Property(x => x.Name).HasColumnName("NOMBRE").HasMaxLength(120);
              }); */

            // modelBuilder.HasDefaultSchema("CLIENTE);
            // modelBuilder.Entity<Product>(b =>
            // {
            //     b.ToTable("TBL_CLIENT");
            //     b.Property(x => x.Id).HasColumnName("CLI_ID");
            //     b.Property(x => x.Name).HasColumnName("CLI_NAME");

            //     b.Property(x => x.Name).HasMaxLength(80);
            //     b.Property(x => x.Id).IsRequired();
            // });
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(x => x.Id).HasColumnName("PRO_ID");
                b.Property(x => x.Name).HasColumnName("PRO_NAME");
                b.Property(x => x.Price).HasColumnName("PRO_PRICE");
                b.Property(x => x.Active).HasColumnName("PRO_ACTIVE");
                // b.Property(x => x.ProductCategory).HasColumnName("PRO_PRODUCTCATEGORY"); //RELACION NO TRADUCIR
                b.Property(x => x.Stock).HasColumnName("PRO_STOCK");
            });
            //ORDER
            modelBuilder.Entity<Order>(b =>
            {
                // b.Property(x => x.Client).HasColumnName("ORD_CLIENT");
                // b.Property(x => x.Details).HasColumnName("ORD_DETAILS");
                b.Property(x => x.Id).HasColumnName("ORD_ID");
                b.Property(x => x.Register).HasColumnName("ORD_REGISTER");
            });
            modelBuilder.Entity<Client>(b =>
            {
                b.Property(x => x.Id).HasColumnName("CLI_ID");
                b.Property(x => x.Name).HasColumnName("CLI_NAME");
            });
            modelBuilder.Entity<OrderDetail>(b =>
            {
                b.Property(x => x.Id).HasColumnName("ORD_ID");
                b.Property(x => x.Price).HasColumnName("ORD_PRICE");
                // b.Property(x => x.Product).HasColumnName("ORD_PRODUCT");
                b.Property(x => x.Count).HasColumnName("ORD_COUNT");
                b.Property(x => x.SubTotal).HasColumnName("ORD_SUBTOTAL");
            });
            modelBuilder.Entity<ProductCategory>(b =>
            {
                b.Property(x => x.Id).HasColumnName("PRO_ID");
                b.Property(x => x.Name).HasColumnName("PRO_NAME");
            });

        }

    }
    public static class EfEjercicios
    {
        public static void CrearProductCategoria()
        {
            var db = new EjemploDBContext();
            var productoId = 1;
            var productoExtists = (from x in db.ProductCategories
                                   where x.Id == productoId
                                   select x).SingleOrDefault();
            if (productoExtists == null)
            {
                ProductCategory pcategory1 = new ProductCategory();
                pcategory1.Id = 1;
                pcategory1.Name = "Medicamento";
                db.Add(pcategory1);
            }
            else
            {
                System.Console.WriteLine($"Producto {productoId} ya existe");
            }
            productoId = 2;
            if (!db.ProductCategories.Any(x => x.Id == productoId))
            {
                ProductCategory pcategory2 = new ProductCategory();
                pcategory2.Id = 2;
                pcategory2.Name = "Alimentos";
                db.Add(pcategory2);
            }

            ProductCategory pcategory3 = new ProductCategory();
            pcategory3.Id = 3;
            pcategory3.Name = "Vestimenta";
            db.SaveChanges();
            System.Console.WriteLine("Creación exitosa");
        }

        public static void Basicos()
        {

            using var db = new EjemploDBContext();

            Console.WriteLine($"Database path: {db.DbPath}.");


            var random = new Random();
            var numero = random.Next(0, 100);


            db.Products.Add(new Product
            {
                Name = $"Foo_{numero}",
                Price = 200.30M,
                Stock = 35
            });

            db.Products.Add(new Product
            {
                Name = $"Bar_{numero}",
                Price = 120M,
                Stock = 10
            });

            //Guardar. 
            db.SaveChanges();

            var listProduct = db.Products.Select(x => x.Name);

            foreach (var item in listProduct)
            {
                Console.WriteLine(item);
            }


            var product = db.Products.OrderByDescending(x => x.Id).FirstOrDefault();

            if (product != null)
            {

                Console.WriteLine($"Update: {product.Name}");

                //Update. 
                product.Name = "Cambiar";
                product.Price = 0;

                var numeroChange = random.Next(0, 100);

                product.Name = $"Cambiar_{numeroChange}";


                db.SaveChanges();

            }

            var productLast = db.Products.OrderByDescending(x => x.Id).LastOrDefault();
            if (productLast != null)
            {
                Console.WriteLine($"Remove: {productLast.Name}");

                //Delete 
                db.Products.Remove(productLast);

                db.SaveChanges();
            }

        }
    }

}


