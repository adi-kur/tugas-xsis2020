using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Xsis
{
    public class VMRekening
    {
        public string NO_REKENING { get; set; }

        public long ID_NASABAH { get; set; }

        public string NAMA { get; set; }

        public long SALDO { get; set; }

        public DateTime UPDATE_DATE { get; set; }

        public string UPDATE_BY { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime CREATED_DATE { get; set; }

        public bool IS_DELETE { get; set; }
    }
}
