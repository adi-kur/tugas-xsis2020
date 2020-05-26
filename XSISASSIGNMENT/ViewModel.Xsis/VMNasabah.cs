using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Xsis
{
    public class VMNasabah
    {
        public long ID_NASABAH { get; set; }

        public string NAMA { get; set; }

        public string NIK { get; set; }

        public string TELEPON { get; set; }

        public string EMAIL { get; set; }

        public string JENIS_KELAMIN { get; set; }

        public DateTime TANGGAL_LAHIR { get; set; }

        public string AGAMA { get; set; }

        public string STATUS { get; set; }

        public string NAMA_IBU_KANDUNG { get; set; }

        public string PEKERJAAN { get; set; }

        public string ALAMAT { get; set; }

        public bool IS_DELETE { get; set; }

        public string UPDATE_BY { get; set; }

        public DateTime UPDATE_DATE { get; set; }

        public string NO_REKENING { get; set; }
        public long SALDO { get; set; }

        public bool IS_KREDIT { get; set; }
    }
}
