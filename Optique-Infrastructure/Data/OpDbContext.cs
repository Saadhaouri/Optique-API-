using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Optique_Domaine.Entities;

namespace Infrastructure.Data
{
    public class OpDbContext : IdentityDbContext<User>
    {
        public OpDbContext(DbContextOptions<OpDbContext> options) : base(options) { }

        public DbSet<Product> Produits { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
       
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<Achat> Achats { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Caisse> Caisses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Verre> Verres { get; set; }
        public DbSet<AchatProduct> AchatProducts { get; set; }
        public DbSet<Visite> Visites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
 .HasKey(op => new { op.OrderId, op.ProductId });


            modelBuilder.Entity<OrderProduct>()
                   .HasOne(op => op.Product)
                   .WithMany(p => p.OrderProducts)
                   .HasForeignKey(op => op.ProductId)
                   .OnDelete(DeleteBehavior.NoAction); // Specify delete behavior




            modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId)
            .OnDelete(DeleteBehavior.NoAction); // Specify delete behavior


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Fournisseur)
                .WithMany(f => f.Produits)
                .HasForeignKey(p => p.FournisseurId)
                .OnDelete(DeleteBehavior.Restrict);
     

            modelBuilder.Entity<Achat>()
                .HasOne(a => a.Fournisseur)
                .WithMany(f => f.Achats)
                .HasForeignKey(a => a.FournisseurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AchatProduct>()
                .HasKey(ap => new { ap.AchatId, ap.ProductId });

            modelBuilder.Entity<AchatProduct>()
                .HasOne(ap => ap.Achat)
                .WithMany(a => a.AchatProducts)
                .HasForeignKey(ap => ap.AchatId);
     
            modelBuilder.Entity<AchatProduct>()
                .HasOne(ap => ap.Produit)
                .WithMany(p => p.AchatProduits)
                .HasForeignKey(ap => ap.ProductId);


       
           


        }
    }
}
