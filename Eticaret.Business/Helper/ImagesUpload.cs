using System;
using System.IO;
using System.Web;

namespace Eticaret.Business
{
    public class ImagesUpload
    {
        public static string Upload(HttpPostedFileBase Resim)
        {
            var R = new Random();
            var YeniAd = "Eticaret_" + R.Next(1, 99999) + ".jpg";
            var DosyaYolu = Path.Combine(HttpContext.Current.Server.MapPath("~/images"),
                YeniAd);
            Resim.SaveAs(DosyaYolu);
            return YeniAd;
        }
        
        public static string LogoUpload(HttpPostedFileBase Resim)
        {
            var R = new Random();
            var YeniAd = "Logo_" + R.Next(1, 99999) + ".png";
            var DosyaYolu = Path.Combine(HttpContext.Current.Server.MapPath("~/Logo"),
                YeniAd);
            Resim.SaveAs(DosyaYolu);
            return YeniAd;
        }
    }
}