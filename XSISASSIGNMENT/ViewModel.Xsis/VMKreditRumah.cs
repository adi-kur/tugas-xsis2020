using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Xsis
{
    public class VMKreditRumah
    {
        public long ID_KREDIT { get; set; }

        public string NO_REKENING { get; set; }

        public string NAMA { get; set; }

        public DateTime TANGGAL_REALISASI { get; set; }

        public decimal PLAFOND { get; set; }

        public long JANGKA_WAKTU { get; set; }

        public decimal PERSEN_BUNGA { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public string CREATED_BY { get; set; }

        public string UPDATE_BY { get; set; }

        public DateTime UPDATE_DATE { get; set; }

        public bool IS_DELETE { get; set; }
    }

    public class VM_RESULT
    {
        public List<VMKreditRumah> data { get; set; }
        public string result { get; set; }
        public string message { get; set; }
    }

    public class VM_Angsuran
    {
        //Bulan Tanggal Angsuran Saldo Pokok Angsuran Pokok Angsuran Bunga Angsuran Total 	% Bunga
        public int Bulan { get; set; }
        public DateTime TanggalAngsuran { get; set; }
        public decimal SaldoPokok { get; set; }
        public decimal AngsuranPokok { get; set; }
        public decimal AngsuranBunga { get; set; }
        public decimal AngsuranTotal { get; set; }
        public decimal Bunga { get; set; }
    }
}
