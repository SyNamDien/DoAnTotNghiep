using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebGiupViec_API.Models
{
    public partial class WEBGIUPVIECContext : DbContext
    {
        public WEBGIUPVIECContext()
        {
        }

        public WEBGIUPVIECContext(DbContextOptions<WEBGIUPVIECContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }
        public virtual DbSet<JobPayment> JobPayments { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SYXNAMDIEN;Database=WEBGIUPVIEC;Integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Mota).IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Diachi).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Ngaysinh)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TenKH");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Customer__RoleID__2C3393D0");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DanhMuc__2725866E1F7C4B90");

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.Property(e => e.TenDm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenDM");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.CongTy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.MoTaDai).IsRequired();

                entity.Property(e => e.MoTaNgan)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.TenCv)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TenCV");

                entity.Property(e => e.ThoiGianLam)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.MaDm)
                    .HasConstraintName("FK__Job__TrangThai__31EC6D26");
            });

            modelBuilder.Entity<JobOffer>(entity =>
            {
                entity.ToTable("JobOffer");

                entity.Property(e => e.JobOfferId).HasColumnName("JobOfferID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Gia)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.NgayBdlam)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("NgayBDLam");

                entity.Property(e => e.NgayDang)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.TrangThaiId).HasColumnName("TrangThaiID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobOffer__Custom__35BCFE0A");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobOffer__JobID__34C8D9D1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__JobOffer__StaffI__36B12243");

                entity.HasOne(d => d.TrangThai)
                    .WithMany(p => p.JobOffers)
                    .HasForeignKey(d => d.TrangThaiId)
                    .HasConstraintName("FK__JobOffer__TrangT__37A5467C");
            });

            modelBuilder.Entity<JobPayment>(entity =>
            {
                entity.ToTable("JobPayment");

                entity.Property(e => e.JobPaymentId).HasColumnName("JobPaymentID");

                entity.Property(e => e.JobOfferId).HasColumnName("JobOfferID");

                entity.Property(e => e.NgayTt)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("NgayTT");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.TongTien)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.JobOffer)
                    .WithMany(p => p.JobPayments)
                    .HasForeignKey(d => d.JobOfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobPaymen__JobOf__3A81B327");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.JobPayments)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__JobPaymen__Payme__3B75D760");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.Property(e => e.PaymentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.MoTaDai).IsRequired();

                entity.Property(e => e.MoTaNgan)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.NgayDang)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TacGia)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("Slide");

                entity.Property(e => e.SlideId).HasColumnName("SlideID");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.Mota)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SlideName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<TrangThai>(entity =>
            {
                entity.ToTable("TrangThai");

                entity.Property(e => e.TrangThaiId).HasColumnName("TrangThaiID");

                entity.Property(e => e.Mota).HasMaxLength(200);

                entity.Property(e => e.TrangThaiName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.DanhGia)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Diachi).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NgayVaoCty)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ngaysinh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SoCvdaLam).HasColumnName("SoCVDaLam");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Staff__RoleID__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
