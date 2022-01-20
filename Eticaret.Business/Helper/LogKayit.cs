using Eticaret.Business;
using Eticaret.Entities;
using System;

namespace Eticaret
{
    public class LogKayit
    {
        public static void LogInsert(Exception e, string Hata)
        {
            var db = new ConnectionBase();
            var log = new TBLLog();
            log.Logs = Hata;
            log.Datetime = DateTime.Now;
            log.ErrorMessage = e.Message + "- " + e.Source;
            log.UserCookies = 1; // Sepet'in ID'si Tutulacak.
            db.context.TBLLog.Add(log);
            db.context.SaveChanges();
        }
    }
}