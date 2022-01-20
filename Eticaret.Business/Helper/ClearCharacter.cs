namespace Eticaret.Business
{
    public class ClearCharacter
    {
        public static string Clear(string data)
        {
            data = data.Replace(",", "").Replace("\"", "-").Replace("'", "").Replace(":", "").Replace(";", "")
                .Replace(".", "").Replace("!", "").Replace("?", "").Replace(")", "").Replace("(", " ").Replace("&", " ")
                .Replace(" ", " ").Replace("#", "sharp");
            if (data.Length > byte.MaxValue)
            {
                data = data.Substring(0, byte.MaxValue);
                data = data.Substring(0, data.LastIndexOf(" "));
            }

            data = data.Replace(" ", "-").ToLower();
            return data.Replace("ş", "s").Replace("Ş", "s").Replace("ç", "c").Replace("Ç", "c").Replace("ö", "o")
                .Replace("Ö", "o").Replace("ü", "u").Replace("Ü", "u").Replace("İ", "i").Replace("ı", "i")
                .Replace("ğ", "g").Replace("Ğ", "g").Replace("/", "-");
        }
    }
}