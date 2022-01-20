using Eticaret.Business;
using Eticaret.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class JSONBasketController : Controller
    {
       
        ConnectionBase db = new ConnectionBase();
        // Geçici Sepet Oluşturma.
        public JsonResult Olustur(string ProductID, string Name, string Price, string DiscountPrice, string images, byte Piece)
        {
            try
            {
                // Aşağıdaki Örnekleme ise : Daha Önce Veritabanı Bağlantısı oluşturulmuş ise bizi o bağlanıdan gitmemizi sağlayan veya Oluşturulmamış ise oluşturmayı sağlayan Sınıfımızdır.

                // Daha Önce Tarayıcıda Çerez Oluşturulmamışsa, Çerez Oluşturulup, Kullanıcının Sepete Eklemek istediği ürünü Sepete Ekliyoruz.
                if (HttpContext.Request.Cookies["BasketCookiesID"] == null)
                {
                    // Daha Önce En son oluşturulan CookiesID'yi alıyoruz.
                    var SonCookiesID = db.context.TBLCookies.OrderByDescending(x => x.GCookiesID).FirstOrDefault();

                    // Veritabanından çektiğimiz CookiesID üzerine +1 ekleyerek yeni data Oluşturuyoruz kullanıcının tarayıcısında.
                    Cookies.Insert("BasketCookiesID", (SonCookiesID.OlusturulanID + 1).ToString());


                    // Yeni Oluşturulan CookieID'yi veritabanında Güncelliyorum.

                    var c = db.context.TBLCookies.Find(1);
                    c.OlusturulanID = SonCookiesID.OlusturulanID + 1;
                    db.context.SaveChanges();
                    //var c = db.context.TBLCookies.Find(1);
                    //c.OlusturulanID = SonCookiesID.OlusturulanID + 1;
                    //db.context.SaveChanges();


                    // Kullanıcın Eklemek istediği ürünü Geçici Sepete  Ekliyoruz.
                    TBLTempBasket Gecici = new TBLTempBasket();
                    Gecici.CookiesID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"].ToString());
                    Gecici.ProductID = Convert.ToInt32(ProductID);
                    Gecici.Piece = Convert.ToByte(Piece);
                    Gecici.Name = Name;
                    Gecici.images = images;
                    Gecici.Price = Convert.ToDecimal(Price.Replace(".", ","));
                    Gecici.DiscountPrice = Convert.ToDecimal(DiscountPrice.Replace(".", ","));
                    db.context.TBLTempBasket.Add(Gecici);
                    db.context.SaveChanges();

                    return Json("Ürün Sepete Eklenmiştir.");
                }
                // Eğer Cookies Daha Önce Oluşturulmuşsa Bu Sefer Eklediği Ürünün Kontrolünü Yapıyoruz.
                // Daha Önce Tıkladığı ürün Sepete Eklenmiş ise Adetini Arttırıyoruz, Daha önce eklenmemişse Ekliyoruz.
                else
                {
                    // Kullanıcın Tarayıcısındaki Çerezi Alıyoruz.
                    int UserCookiesID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"].ToString());

                    int ID = Convert.ToInt32(ProductID);
                    //Any => Eğer ürün varsa True yoksa false cevabını dönderir.
                    if (db.context.TBLTempBasket.Any(x => x.CookiesID == UserCookiesID && x.ProductID == ID))
                    {
                        var data = db.context.TBLTempBasket.Where(x => x.CookiesID == UserCookiesID && x.ProductID == ID).FirstOrDefault();

                        TBLTempBasket t = db.context.TBLTempBasket.Find(data.BasketID);
                        t.Piece += 1;
                        db.context.SaveChanges();
                        // Eğer Tıkladığı ürün var ise adetini Arttırıyoruz.
                        // Burada Adet Arttıracağız.
                        return Json("Sepetinizdeki Ürünün Adeti Arttırılmıştır.");
                    }
                    else
                    {
                        // Eğer ürün Daha önce eklenmemişse  Ürünü Geçici Sepete Ekliyoruz.
                        TBLTempBasket Gecici = new TBLTempBasket();
                        Gecici.CookiesID = UserCookiesID;
                        Gecici.ProductID = ID;
                        Gecici.Piece = Convert.ToByte(Piece);
                        Gecici.Name = Name;
                        Gecici.Price = Convert.ToDecimal(Price.Replace(".", ","));
                        Gecici.images = images;
                        Gecici.DiscountPrice = Convert.ToDecimal(DiscountPrice.Replace(".", ","));
                        db.context.TBLTempBasket.Add(Gecici);
                        db.context.SaveChanges();
                        return Json("Ürün Sepete Eklenmiştir.");
                    }
                }

            }
            catch (Exception e)
            {
                // Eticaret.Business İçerisinde Oluşturmuş olduğum LogKayit Class'ındaki LogInsert Method'unu Çağıyorum, Bu Metot içerisinde Benim Yerime Tabloya Otomatik Kayıt Yapan Kod Yapım vardır.
                LogKayit.LogInsert(e, "JsonBasketControl.cs - Olustur Method Hata.");
                // Kodlarda Hata Çıkarma Kullanıcı Kandırmak için Oluşturulan Bölüm :)
                return Json("Beklenmedik Bir Hata ile Karşılaşıldı, Lütfen Tekrar Deneyiniz.");
            }
        }

        public JsonResult ProductDelete(string TempBasketID)
        {
            try
            {
                int UserCookiesID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"].ToString());
                int UrunID = Convert.ToInt32(TempBasketID);

                var data = db.context.TBLTempBasket.Where(x => x.CookiesID == UserCookiesID && x.ProductID == UrunID).FirstOrDefault();

                db.context.TBLTempBasket.Remove(db.context.TBLTempBasket.Find(data.BasketID));
                db.context.SaveChanges();

                return Json("Ürün Sepetinizden Silinmiştir.");
            }
            catch (Exception e)
            {
                // Eticaret.Business İçerisinde Oluşturmuş olduğum LogKayit Class'ındaki LogInsert Method'unu Çağıyorum, Bu Metot içerisinde Benim Yerime Tabloya Otomatik Kayıt Yapan Kod Yapım vardır.
                LogKayit.LogInsert(e, "JsonBasketControl.cs - ProductDelete Method Hata.");
                // Kodlarda Hata Çıkarma Kullanıcı Kandırmak için Oluşturulan Bölüm :)
                return Json("Beklenmedik Bir Hata ile Karşılaşıldı, Lütfen Tekrar Deneyiniz.");
            }
        }
        // Sepetteki Ürünün Adetiyla Oynandığında Çalışacak
        // adet Arttırmaya tıkladığında artacak. Adet Azalttmaya Tıkladığımd Azalacak. 
        public JsonResult ProductPiece(string ProductID, string Adet)
        {
            try
            {
                int SepetID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"].ToString());
                int GelenAdet = Convert.ToInt32(Adet);
                int GelenID = Convert.ToInt32(ProductID);

                var Data = db.context.TBLTempBasket.Where(x => x.CookiesID == SepetID && x.ProductID == GelenID).FirstOrDefault();

                if (Data != null)
                {
                    //Adet 1'den Büyük ise adet azaltılabilecek ve arttırılabilecektir.
                    if (Data.Piece > 1 && GelenAdet == -1)
                    {
                        TBLTempBasket t = db.context.TBLTempBasket.Find(Data.BasketID);
                        t.Piece -= 1;
                        db.context.SaveChanges();
                    }
                    else if (Data.Piece >= 1 && GelenAdet == 1)
                    {
                        TBLTempBasket t = db.context.TBLTempBasket.Find(Data.BasketID);
                        t.Piece += 1;
                        db.context.SaveChanges();
                    }
                }
                return Json("");
            }
            catch (Exception e)
            {
                // Eticaret.Business İçerisinde Oluşturmuş olduğum LogKayit Class'ındaki LogInsert Method'unu Çağıyorum, Bu Metot içerisinde Benim Yerime Tabloya Otomatik Kayıt Yapan Kod Yapım vardır.
                LogKayit.LogInsert(e, "JsonBasketControl.cs - ProductPiece Method Hata.");
                // Kodlarda Hata Çıkarma Kullanıcı Kandırmak için Oluşturulan Bölüm :)
                return Json("Beklenmedik Bir Hata ile Karşılaşıldı, Lütfen Tekrar Deneyiniz.");
            }
        }
    }
}