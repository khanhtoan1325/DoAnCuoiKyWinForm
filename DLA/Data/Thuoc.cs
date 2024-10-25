namespace DLA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thuoc()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public int IDThuoc { get; set; }

        [StringLength(255)]
        public string TenThuoc { get; set; }

        public decimal GiaBan { get; set; }

        public int? IDDVTinh { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HSD { get; set; }

        public int? IDNCC { get; set; }

        public int? IDNhomThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhomThuoc NhomThuoc { get; set; }
    }
}
