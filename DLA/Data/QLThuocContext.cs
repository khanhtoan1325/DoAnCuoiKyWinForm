using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DLA.Data
{
    public partial class QLThuocContext : DbContext
    {
        public QLThuocContext()
            : base("name=QLThuocContext")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhomThuoc> NhomThuocs { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.GiaBan)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ChiTietHoaDon>()
                .Property(e => e.DonVi)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .Property(e => e.TenDVT)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .HasMany(e => e.Thuocs)
                .WithOptional(e => e.DonViTinh)
                .HasForeignKey(e => e.IDDVTinh);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.GiaBan)
                .HasPrecision(10, 2);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.ThanhTien)
                .HasPrecision(15, 2);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.HoTen)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.TenNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.DiaChi)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhomThuoc>()
                .Property(e => e.TenNhomThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.TenThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Thuoc>()
                .Property(e => e.GiaBan)
                .HasPrecision(10, 2);

            modelBuilder.Entity<VaiTro>()
                .Property(e => e.TenVaiTro)
                .IsUnicode(false);

            modelBuilder.Entity<VaiTro>()
                .Property(e => e.IDDangNhap)
                .IsUnicode(false);
        }
    }
}
