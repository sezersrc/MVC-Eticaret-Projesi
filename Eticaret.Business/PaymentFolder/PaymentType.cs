namespace Eticaret
{
    public class PaymentType
    {
        public static bool KrediKarti()
        {
            // SMS, Kredi Kartı Entegrasyon,Email  gibi Kodlamalar Bulunacaktır.
            return true;
        }

        public static bool HavaleileOdeme()
        {
            // SMS, Email  gibi Kodlamalar Bulunacaktır.
            return true;
        }

        public static bool KapidaOdeme()
        {
            // SMS, Email  gibi Kodlamalar Bulunacaktır.
            return true;
        }
    }
}