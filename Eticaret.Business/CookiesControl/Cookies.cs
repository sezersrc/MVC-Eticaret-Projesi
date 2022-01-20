using System;
using System.Web;

namespace Eticaret.Business
{
    public class Cookies
    {
        public static void Insert(string CookiesAdi, string CookiesValue)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(CookiesAdi)
            {
                [CookiesAdi] = CookiesValue,
                Expires = DateTime.Now.AddDays(5)
            });
        }
        public static void CustomerInsert(string CookiesAdi, string CookiesValue)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(CookiesAdi)
            {
                [CookiesAdi] = CookiesValue,
                Expires = DateTime.Now.AddDays(5)
            });
        }
    }
}