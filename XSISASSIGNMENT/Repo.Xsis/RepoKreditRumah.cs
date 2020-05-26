using Model.Xsis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Xsis;
using System.Data.Entity;

namespace Repo.Xsis
{
    public class RepoKreditRumah
    {

        public static List<VMKreditRumah> GetALL()
        {
            List<VMKreditRumah> result = new List<VMKreditRumah>();
            using (
                Model1 db = new Model1())
            {
                result = db.TB_KREDIT_RUMAH.Where(x => x.IS_DELETE == false).Select(x => new VMKreditRumah
                {
                    ID_KREDIT = x.ID_KREDIT,
                    NO_REKENING = x.NO_REKENING.ToString(),
                    NAMA = db.TB_NASABAH
                                .Where(x1 => x1.ID_NASABAH == db.TB_REKENING
                                                                .Where(x2 => x2.ID_NASABAH == x1.ID_NASABAH && x2.NO_REKENING == x.NO_REKENING)
                                                                .Select(x2 => x2.ID_NASABAH).FirstOrDefault())
                                .Select(x1 => x1.NAMA)
                                .FirstOrDefault(),
                    TANGGAL_REALISASI = x.TANGGAL_REALISASI,
                    PLAFOND = x.PLAFOND,
                    JANGKA_WAKTU = x.JANGKA_WAKTU,
                    PERSEN_BUNGA = x.PERSEN_BUNGA
  

                }).ToList();
            }

            return result;
        }

        public static string Create(VMKreditRumah data)
        {
            string result = "ok";

            using (Model1 db = new Model1())
            {
                try
                {
                    db.TB_KREDIT_RUMAH.Add(new TB_KREDIT_RUMAH
                    {
                        NO_REKENING = data.NO_REKENING,
                        JANGKA_WAKTU = data.JANGKA_WAKTU,
                        NAMA = "",
                        PERSEN_BUNGA = data.PERSEN_BUNGA,
                        PLAFOND = data.PLAFOND,
                        TANGGAL_REALISASI = data.TANGGAL_REALISASI,
                        CREATED_BY = "System",
                        CREATED_DATE = DateTime.Now,
                        IS_DELETE = false
                    });
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
                
            }

            return result;
        }

        public static List<VM_Angsuran> HitungAngsuran(long id)
        {
            List<VM_Angsuran> result = new List<VM_Angsuran>();

            try
            {
                VMKreditRumah data = new VMKreditRumah();
                using (Model1 db = new Model1())
                {
                    data = db.TB_KREDIT_RUMAH.Where(x => x.ID_KREDIT == id).Select(x => new VMKreditRumah
                    {
                        TANGGAL_REALISASI = x.TANGGAL_REALISASI,
                        PLAFOND = x.PLAFOND,
                        JANGKA_WAKTU = x.JANGKA_WAKTU,
                        PERSEN_BUNGA = x.PERSEN_BUNGA
                    }).FirstOrDefault();
                }

                for (int i = 0; i <= data.JANGKA_WAKTU; i++)
                {
                    result.Add(new VM_Angsuran
                    {
                        Bulan = i,
                        TanggalAngsuran = data.TANGGAL_REALISASI.AddMonths(i),
                        SaldoPokok = data.PLAFOND,
                        Bunga = data.PERSEN_BUNGA
                    });
                    double JangkaWaktu = data.JANGKA_WAKTU - (i - 1);
                    if (i != 0)
                    {
                        double SaldoPokokPrev = Convert.ToDouble(result.Where(x => x.Bulan == i - 1).Select(x => x.SaldoPokok).FirstOrDefault());
                        double BungaPrev = Convert.ToDouble(result.Where(x => x.Bulan == i - 1).Select(x => x.Bunga).FirstOrDefault());

                        double test1 = Convert.ToDouble(1) - Math.Pow(Convert.ToDouble(1) + (Convert.ToDouble(BungaPrev) / Convert.ToDouble(100)) / Convert.ToDouble(12), JangkaWaktu * Convert.ToDouble(-1));

                        double AngsuranTotal = SaldoPokokPrev * ((BungaPrev / Convert.ToDouble(100)) / Convert.ToDouble(12)) / (test1);
                        double AngsuranBunga = SaldoPokokPrev * (BungaPrev / Convert.ToDouble(100)) * (Convert.ToDouble(30) / Convert.ToDouble(360));
                        double AngsuranPokok = AngsuranTotal - AngsuranBunga;

                        result[i].AngsuranTotal = Convert.ToDecimal(AngsuranTotal);
                        result[i].AngsuranBunga = Convert.ToDecimal(AngsuranBunga);
                        result[i].AngsuranPokok = Convert.ToDecimal(AngsuranPokok);
                        result[i].SaldoPokok = Convert.ToDecimal(SaldoPokokPrev - AngsuranPokok);
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public static string HapusData(long IdNasabah)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    TB_KREDIT_RUMAH datalama = db.TB_KREDIT_RUMAH.Where(a => a.ID_KREDIT == IdNasabah).FirstOrDefault();

                    datalama.IS_DELETE = true;


                    db.SaveChanges();
                    return "ok";
                }

            }
            catch (Exception e)
            {
                return e.Message.ToString();
                throw;
            }
        }

    }
}
