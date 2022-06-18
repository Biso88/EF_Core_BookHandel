using Microsoft.EntityFrameworkCore;

namespace EF_Core_BookHandel.Models
{
    public partial class BookHandelContext : DbContext
    {
        public BookHandelContext()
        {
        }

        public BookHandelContext(DbContextOptions<BookHandelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorsBook> AuthorsBooks { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoresBalance> StoresBalances { get; set; } = null!;
        public virtual DbSet<VTittlePerAuthor> VTittlePerAuthors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookHandel;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorsBook>(entity =>
            {
                entity.HasOne(d => d.Authors)
                    .WithMany()
                    .HasForeignKey(d => d.AuthorsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorsBooks_Authors");

                entity.HasOne(d => d.Isbn13Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.Isbn13)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorsBooks_Books");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Isbn13).ValueGeneratedNever();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Order)
                    .HasForeignKey<Order>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Isbn13Navigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Isbn13)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Books");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("FK_Stores_Orders");
            });

            modelBuilder.Entity<StoresBalance>(entity =>
            {
                entity.HasOne(d => d.Isbn13Navigation)
                    .WithMany(p => p.StoresBalances)
                    .HasForeignKey(d => d.Isbn13)
                    .HasConstraintName("FK_StoresBalance_Books");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoresBalances)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoresBalance_Stores");
            });

            modelBuilder.Entity<VTittlePerAuthor>(entity =>
            {
                entity.ToView("V_TittlePerAuthor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
