using Model.Xsis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Xsis;

namespace Repo.Xsis
{
    public class RepoNasabah
    {
        public static List<VMNasabah> GetALL()
        {
            List<VMNasabah> result = new List<VMNasabah>();
            using (
                Model1 db = new Model1())
            {
                result = db.TB_NASABAH.Where(x => x.IS_DELETE == false).Select(x => new VMNasabah
                {
                    ID_NASABAH = x.ID_NASABAH,
                    NIK = x.NIK,
                    NAMA = x.NAMA,
                    EMAIL = x.EMAIL,
                    ALAMAT = x.ALAMAT,
                    TELEPON = x.TELEPON,
                    AGAMA = x.AGAMA,
                    STATUS = x.STATUS,
                    TANGGAL_LAHIR = x.TANGGAL_LAHIR,
                    NAMA_IBU_KANDUNG = x.NAMA_IBU_KANDUNG,
                    JENIS_KELAMIN = x.JENIS_KELAMIN,
                    PEKERJAAN = x.PEKERJAAN,
                    NO_REKENING = db.TB_REKENING.Where(x2 => x2.ID_NASABAH == x.ID_NASABAH).Select(x2 => x2.NO_REKENING).FirstOrDefault(),
                    IS_KREDIT = db.TB_KREDIT_RUMAH
                        .Where(x2 =>
                                x2.IS_DELETE == false 
                                &&
                                x2.NO_REKENING == db.TB_REKENING
                                                        .Where(x3 => x3.ID_NASABAH == x.ID_NASABAH)
                                                        .Select(x3 => x3.NO_REKENING)
                                                        .FirstOrDefault()
                        ).Count() > 0 
                        ? true : false
                }).ToList();
            }

            return result;
        }

        public static string savedata(VMNasabah Nasabah)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    TB_NASABAH data = new TB_NASABAH();
                    
                    db.TB_NASABAH.Add(new TB_NASABAH
                    {
                        AGAMA = Nasabah.AGAMA,
                        ALAMAT = Nasabah.ALAMAT,
                        EMAIL = Nasabah.EMAIL,
                        NAMA_IBU_KANDUNG = Nasabah.NAMA_IBU_KANDUNG,
                        PEKERJAAN = Nasabah.PEKERJAAN,
                        TELEPON = Nasabah.TELEPON,
                        IS_DELETE = false,
                        JENIS_KELAMIN = Nasabah.JENIS_KELAMIN,
                        NAMA = Nasabah.NAMA,
                        NIK = Nasabah.NIK,
                        STATUS = Nasabah.STATUS,
                        TANGGAL_LAHIR = Nasabah.TANGGAL_LAHIR,
                        UPDATE_BY = "System",
                        UPDATE_DATE = DateTime.Now,
                        
                    }) ;
                    db.SaveChanges();


                    TB_REKENING data2 = new TB_REKENING();
                    data2.ID_NASABAH = db.TB_NASABAH.OrderByDescending(x => x.ID_NASABAH).Select(x => x.ID_NASABAH).FirstOrDefault();
                    string newRek = "000 - " + data2.ID_NASABAH.ToString("D3");
                    data2.NO_REKENING = newRek;
                    data2.SALDO = Nasabah.SALDO;
                    data2.CREATED_BY = "System";
                    data2.CREATED_DATE = DateTime.Now;
                    data2.IS_DELETE = false;

                    db.TB_REKENING.Add(data2);
                    db.SaveChanges();
                }
                return "ok";

            }
            catch (Exception e)
            {

                return e.Message.ToString();
                throw;
            }

        }

        public static VMNasabah GetDataByID(long id)
        {
            VMNasabah result = new VMNasabah();
            try
            {
                using (Model1 db = new Model1())
                {
                    result = db.TB_NASABAH.Where(a => a.ID_NASABAH == id).Select(x => new VMNasabah 
                    {
                        ID_NASABAH = x.ID_NASABAH,
                        NAMA = x.NAMA,
                        NIK = x.NIK,
                        EMAIL = x.EMAIL,
                        TELEPON = x.TELEPON,
                        JENIS_KELAMIN = x.JENIS_KELAMIN,
                        STATUS = x.STATUS,
                        TANGGAL_LAHIR = x.TANGGAL_LAHIR,
                        NAMA_IBU_KANDUNG = x.NAMA_IBU_KANDUNG,
                        PEKERJAAN = x.PEKERJAAN,
                        AGAMA = x.AGAMA,
                        ALAMAT = x.ALAMAT,
                        UPDATE_BY = "System",
                        UPDATE_DATE = DateTime.Now,
                        NO_REKENING = db.TB_REKENING.Where(x1 => x1.ID_NASABAH == id).Select(x1 => x1.NO_REKENING).FirstOrDefault(),
                        SALDO = db.TB_REKENING.Where(x1 => x1.ID_NASABAH == id).Select(x1 => x1.SALDO).FirstOrDefault()
                    }).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static string editdata(VMNasabah Nasabah)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    TB_NASABAH datalama = db.TB_NASABAH.Where(a => a.ID_NASABAH == Nasabah.ID_NASABAH).FirstOrDefault();

                    datalama.NAMA = Nasabah.NAMA;
                    datalama.NIK = Nasabah.NIK;
                    datalama.EMAIL = Nasabah.EMAIL;
                    datalama.TELEPON = Nasabah.TELEPON;
                    datalama.JENIS_KELAMIN = Nasabah.JENIS_KELAMIN;
                    datalama.STATUS = Nasabah.STATUS;
                    datalama.TANGGAL_LAHIR = Nasabah.TANGGAL_LAHIR;
                    datalama.NAMA_IBU_KANDUNG = Nasabah.NAMA_IBU_KANDUNG;
                    datalama.PEKERJAAN = Nasabah.PEKERJAAN;
                    datalama.AGAMA = Nasabah.AGAMA;
                    datalama.ALAMAT = Nasabah.ALAMAT;
                    datalama.UPDATE_BY = "System";
                    datalama.UPDATE_DATE = DateTime.Now;

                    TB_REKENING dataRekPrev = db.TB_REKENING.Where(x => x.ID_NASABAH == Nasabah.ID_NASABAH).FirstOrDefault();

                    dataRekPrev.SALDO = Nasabah.SALDO;
                    dataRekPrev.UPDATE_BY = "System";
                    dataRekPrev.UPDATE_DATE = DateTime.Now;


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

        public static string HapusData(long IdNasabah)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    TB_NASABAH datalama = db.TB_NASABAH.Where(a => a.ID_NASABAH == IdNasabah).FirstOrDefault();

                    datalama.IS_DELETE = true;

                    TB_REKENING dataRek = db.TB_REKENING.Where(x => x.ID_NASABAH == IdNasabah).FirstOrDefault();
                    dataRek.IS_DELETE = true;


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


