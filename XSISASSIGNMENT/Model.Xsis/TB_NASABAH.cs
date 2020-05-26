namespace Model.Xsis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_NASABAH
    {
        [Key]
        public long ID_NASABAH { get; set; }

        [Required]
        [StringLength(50)]
        public string NAMA { get; set; }

        [Required]
        [StringLength(16)]
        public string NIK { get; set; }

        [Required]
        [StringLength(15)]
        public string TELEPON { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string JENIS_KELAMIN { get; set; }

        public DateTime TANGGAL_LAHIR { get; set; }

        [StringLength(20)]
        public string AGAMA { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        [StringLength(50)]
        public string NAMA_IBU_KANDUNG { get; set; }

        [StringLength(50)]
        public string PEKERJAAN { get; set; }

        [StringLength(50)]
        public string ALAMAT { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string UPDATE_BY { get; set; }

        public DateTime UPDATE_DATE { get; set; }
    }
}
