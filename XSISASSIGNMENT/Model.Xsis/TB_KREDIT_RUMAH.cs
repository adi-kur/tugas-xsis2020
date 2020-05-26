namespace Model.Xsis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_KREDIT_RUMAH
    {
        [Key]
        public long ID_KREDIT { get; set; }

        [Required]
        [StringLength(16)]
        public string NO_REKENING { get; set; }

        [StringLength(50)]
        public string NAMA { get; set; }

        public DateTime TANGGAL_REALISASI { get; set; }

        public decimal PLAFOND { get; set; }

        public long JANGKA_WAKTU { get; set; }

        public decimal PERSEN_BUNGA { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public string UPDATE_BY { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public bool IS_DELETE { get; set; }
    }
}
