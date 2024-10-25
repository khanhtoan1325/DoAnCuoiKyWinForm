namespace DLA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomThuoc")]
    public partial class NhomThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomThuoc()
        {
            Thuocs = new HashSet<Thuoc>();
        }

        [Key]
        public int IDNhomThuoc { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNhomThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thuoc> Thuocs { get; set; }
    }
}
