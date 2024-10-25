namespace DLA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        public int IDCTHD { get; set; }

        public int? IDThuoc { get; set; }

        public int? IDHoaDon { get; set; }

        public decimal GiaBan { get; set; }

        public int SoLuong { get; set; }

        [StringLength(50)]
        public string DonVi { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual Thuoc Thuoc { get; set; }
    }
}
