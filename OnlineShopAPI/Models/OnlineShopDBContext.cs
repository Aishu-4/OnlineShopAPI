using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineShopAPI.Models
{
    public partial class OnlineShopDBContext : DbContext
    {
        public OnlineShopDBContext()
        {
        }

        public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<TblCart> TblCart { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblCompare> TblCompare { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblRetailer> TblRetailer { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblWishlist> TblWishlist { get; set; }
        public virtual DbSet<TypeOfUsers> TypeOfUsers { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Admins__A9D10534D30BB162")
                    .IsUnique();

                entity.HasIndex(e => e.MobNo)
                    .HasName("UQ__Admins__FB9C10DB69BE4E11")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__Admins__UserType__145C0A3F");
            });

            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.Cartid)
                    .HasName("PK__tblCart__41663FC040E2F634");

                entity.ToTable("tblCart");

                entity.Property(e => e.Cartid).HasColumnName("cartid");

                entity.Property(e => e.Cartquantity).HasColumnName("cartquantity");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCart__product__30F848ED");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCart__userema__300424B4");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("PK__tblCateg__23CDE590844FFD5D");

                entity.ToTable("tblCategory");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Categorydescription).HasColumnName("categorydescription");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname");
            });

            modelBuilder.Entity<TblCompare>(entity =>
            {
                entity.ToTable("tblCompare");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCompare)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCompar__Produ__33D4B598");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblCompare)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblCompar__usere__34C8D9D1");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK__tblOrder__080E3775B11C5F5D");

                entity.ToTable("tblOrder");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date");

                entity.Property(e => e.Orderprice).HasColumnName("orderprice");

                entity.Property(e => e.Orderquantity).HasColumnName("orderquantity");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Retailerid).HasColumnName("retailerid");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK__tblOrder__produc__2C3393D0");

                entity.HasOne(d => d.Retailer)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.Retailerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblOrder__retail__2D27B809");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblOrder__userem__2B3F6F97");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK__tblProdu__2D172D324607C4D4");

                entity.ToTable("tblProduct");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Productbrand)
                    .HasColumnName("productbrand")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Productdescription).HasColumnName("productdescription");

                entity.Property(e => e.Productimage1).HasColumnName("productimage1");

                entity.Property(e => e.Productname).HasColumnName("productname");

                entity.Property(e => e.Productnotification)
                    .HasColumnName("productnotification")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Productprice).HasColumnName("productprice");

                entity.Property(e => e.Productquantity).HasColumnName("productquantity");

                entity.Property(e => e.Productstatus)
                    .HasColumnName("productstatus")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.Retailerid).HasColumnName("retailerid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblProduc__categ__286302EC");

                entity.HasOne(d => d.Retailer)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.Retailerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblProduc__retai__276EDEB3");
            });

            modelBuilder.Entity<TblRetailer>(entity =>
            {
                entity.HasKey(e => e.Retailerid)
                    .HasName("PK__tblRetai__7A12C3E04429959D");

                entity.ToTable("tblRetailer");

                entity.HasIndex(e => e.Aadhar)
                    .HasName("UQ__tblRetai__6C9F238ECF3F640E")
                    .IsUnique();

                entity.HasIndex(e => e.Gst)
                    .HasName("UQ__tblRetai__C51F7EFCACD5BD3F")
                    .IsUnique();

                entity.HasIndex(e => e.MobNo)
                    .HasName("UQ__tblRetai__FB9C10DB4CB92AF7")
                    .IsUnique();

                entity.HasIndex(e => e.Pan)
                    .HasName("UQ__tblRetai__C570980556674CBF")
                    .IsUnique();

                entity.HasIndex(e => e.Retaileremail)
                    .HasName("UQ__tblRetai__F3B103331BB005BF")
                    .IsUnique();

                entity.Property(e => e.Retailerid).HasColumnName("retailerid");

                entity.Property(e => e.Aadhar)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Approved)
                    .HasColumnName("approved")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.CompanyDetails)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gst)
                    .IsRequired()
                    .HasColumnName("GST")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Pan)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Retaileremail)
                    .IsRequired()
                    .HasColumnName("retaileremail")
                    .HasMaxLength(40);

                entity.Property(e => e.Retailername)
                    .IsRequired()
                    .HasColumnName("retailername")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Retailerpassword)
                    .IsRequired()
                    .HasColumnName("retailerpassword")
                    .HasMaxLength(40);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.TblRetailer)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__tblRetail__UserT__1ED998B2");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.Useremail)
                    .HasName("PK__tblUser__870EAE60BA354656");

                entity.ToTable("tblUser");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Userpassword)
                    .IsRequired()
                    .HasColumnName("userpassword")
                    .HasMaxLength(20);

                entity.Property(e => e.Userphone)
                    .IsRequired()
                    .HasColumnName("userphone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK__tblUser__UserTyp__173876EA");
            });

            modelBuilder.Entity<TblWishlist>(entity =>
            {
                entity.ToTable("tblWishlist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.Useremail)
                    .HasColumnName("useremail")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblWishlist)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblWishli__Produ__37A5467C");

                entity.HasOne(d => d.UseremailNavigation)
                    .WithMany(p => p.TblWishlist)
                    .HasForeignKey(d => d.Useremail)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tblWishli__usere__38996AB5");
            });

            modelBuilder.Entity<TypeOfUsers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
