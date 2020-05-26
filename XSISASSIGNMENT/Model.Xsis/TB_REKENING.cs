namespace Model.Xsis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TB_REKENING
    {
        [Key]
        [StringLength(16)]
        public string NO_REKENING { get; set; }

        public long ID_NASABAH { get; set; }

        public long SALDO { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        [StringLength(50)]
        public string UPDATE_BY { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public bool IS_DELETE { get; set; }
    }
}
