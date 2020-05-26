using Model.Xsis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Xsis;

namespace Repo.Xsis
{
    public class RepoRekening
    {
        public static List<VMRekening> GetALL()
        {
            List<VMRekening> result = new List<VMRekening>();
            using (
                Model1 db = new Model1())
            {
                result = db.TB_REKENING.Where(x => x.IS_DELETE == false).Select(x => new VMRekening
                {

                    ID_NASABAH = x.ID_NASABAH,
                    NO_REKENING = x.NO_REKENING,
                    NAMA = db.TB_NASABAH.Where(x2 => x2.ID_NASABAH == x.ID_NASABAH).Select(x2 => x2.NAMA).FirstOrDefault(),
                    SALDO = x.SALDO

                }).ToList();
            }

            return result;
        }
    }
}
