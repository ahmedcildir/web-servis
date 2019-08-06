using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using WebServis.DB;

namespace WebServis
{
    /// <summary>
    /// Summary description for WebServis
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServis : System.Web.Services.WebService
    {
        /*Hash şifreleme işlemi nedir, orjinal verinin kullanılan hash algoritmasına göre şifrelenerek, 
          ona karşılık gelen benzersiz bir değer oluşturulması işlemidir.
         * Şifrelemede kullanılan Algoritma.
         * MD5, girdi verisini şifrelemek için 128 bit şifreleyici kullanır*/
        //Şifreleme anahtarı
        public string hash = "AhmedÇILDIR";

        [WebMethod]//Veriyi Şifreleme
        public string Sifrele(string sifre)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        [WebMethod]//Şifrelenmiş veriyi Çözme
        public string SifreCoz(string SifrelenmisDeger)
        {
            byte[] data = Convert.FromBase64String(SifrelenmisDeger);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        //[WebMethod]
        //public string AlfabedenMorse(string g)
        //{
        //    string k = g;
        //    string z = k.ToLower();
        //    string y = z;
        //    y = y.Replace("a", ".....");
        //    y = y.Replace("b", "....-");
        //    y = y.Replace("c", "...-.");
        //    y = y.Replace("ç", "..-..");
        //    y = y.Replace("d", ".-...");
        //    y = y.Replace("e", "-....");
        //    y = y.Replace("f", "...--");
        //    y = y.Replace("g", "..-.-");
        //    y = y.Replace("ğ", "..--.");
        //    y = y.Replace("h", ".-..-");
        //    y = y.Replace("ı", ".-.-.");
        //    y = y.Replace("i", ".--..");
        //    y = y.Replace("j", "-...-");
        //    y = y.Replace("k", "-..-.");
        //    y = y.Replace("l", "-.-..");
        //    y = y.Replace("m", "--...");
        //    y = y.Replace("n", "..---");
        //    y = y.Replace("o", ".-.--");
        //    y = y.Replace("ö", ".--.-");
        //    y = y.Replace("p", ".---.");
        //    y = y.Replace("r", "-..--");
        //    y = y.Replace("s", "-.-.-");
        //    y = y.Replace("ş", "-.--.");
        //    y = y.Replace("t", "--..-");
        //    y = y.Replace("u", "--.-.");
        //    y = y.Replace("ü", "---..");
        //    y = y.Replace("v", ".----");
        //    y = y.Replace("y", "-.---");
        //    y = y.Replace("z", "--.--");
        //    //y = y.Replace(".", "...._");
        //    y = y.Replace(" ", "-----");

        //    return y.ToString();
        //}

        //[WebMethod]
        //public string MorsedenAlfabeden(string g)
        //{
        //    string k = g;
        //    string z = k.ToLower();
        //    int o = z.Length - 5;
        //    string m = "";
        //    for (int x = 0; x <= o; x += 5)
        //    {
        //        string p = z.Substring(x, 5);
        //        p = p.Replace(".....", "a");
        //        p = p.Replace("....-", "b");
        //        p = p.Replace("...-.", "c");
        //        p = p.Replace("..-..", "ç");
        //        p = p.Replace(".-...", "d");
        //        p = p.Replace("-....", "e");
        //        p = p.Replace("...--", "f");
        //        p = p.Replace("..-.-", "g");
        //        p = p.Replace("..--.", "ğ");
        //        p = p.Replace(".-..-", "h");
        //        p = p.Replace(".-.-.", "ı");
        //        p = p.Replace(".--..", "i");
        //        p = p.Replace("-...-", "j");
        //        p = p.Replace("-..-.", "k");
        //        p = p.Replace("-.-..", "l");
        //        p = p.Replace("--...", "m");
        //        p = p.Replace("..---", "n");
        //        p = p.Replace(".-.--", "o");
        //        p = p.Replace(".--.-", "ö");
        //        p = p.Replace(".---.", "p");
        //        p = p.Replace("-..--", "r");
        //        p = p.Replace("-.-.-", "s");
        //        p = p.Replace("-.--.", "ş");
        //        p = p.Replace("--..-", "t");
        //        p = p.Replace("--.-.", "u");
        //        p = p.Replace("---..", "ü");
        //        p = p.Replace(".----", "v");
        //        p = p.Replace("-.---", "y");
        //        p = p.Replace("--.--", "z");
        //        //p = p.Replace("...._", ".");
        //        p = p.Replace("-----", " ");


        //        //p = p.Replace("......", "A");
        //        //p = p.Replace(".....-", "B");
        //        //p = p.Replace("....-.", "C");
        //        //p = p.Replace("...-..", "Ç");
        //        //p = p.Replace("D", "..-...");
        //        //p = p.Replace("E", ".-....");
        //        //p = p.Replace("F", "....--");
        //        //p = p.Replace("G", "...-.-");
        //        //p = p.Replace("Ğ", "...--.");
        //        //p = p.Replace("H", "..-..-");
        //        //p = p.Replace("I", "..-.-.");
        //        //p = p.Replace("İ", "..--..");
        //        //p = p.Replace("J", ".-...-");
        //        //p = p.Replace("K", ".-..-.");
        //        //p = p.Replace("L", ".-.-..");
        //        //p = p.Replace("M", ".--...");
        //        //p = p.Replace("N", "...---");
        //        //p = p.Replace("O", "..-.--");
        //        //p = p.Replace("Ö", "..--.-");
        //        //p = p.Replace("P", "..---.");
        //        //p = p.Replace("R", ".-..--");
        //        //p = p.Replace("S", ".-.-.-");
        //        //p = p.Replace("Ş", ".-.--.");
        //        //p = p.Replace("T", ".--..-");
        //        //p = p.Replace("U", ".--.-.");
        //        //p = p.Replace("Ü", ".---..");
        //        //p = p.Replace("V", "..----");
        //        //p = p.Replace("Y", ".-.---");
        //        //p = p.Replace("Z", ".--.--");
        //        m = m + p;
        //    }
        //    return m.ToString();
        //}

        [WebMethod]
        public bool KullaniciGiris(string KullaniciAd, string Sifre)
        {

            LoginDBContext ctx = new LoginDBContext();
            var q1 = from p in ctx.tbKullanicilers
                     where p.Kullanici_Ad == KullaniciAd
                     && p.Sifre == Sifre
                     select p;
            
            if (q1.Any())
            {
               
                //Session["id"] = q2.id;

                return true;
            }
            else
            {

                return false;
            }
            
        }
        [WebMethod]
        public string id(string KullaniciAd, string Sifre)
        {

            LoginDBContext ctx = new LoginDBContext();
            var q2 = ctx.tbKullanicilers
                   .Where(x => x.Kullanici_Ad == KullaniciAd && x.Sifre == Sifre).FirstOrDefault();
            return q2.id.ToString();
        }


        [WebMethod]
        public List<uye> Kullan()
        {
            LoginDBContext ctx = new LoginDBContext();

            return ctx.tbKullanicilers.Select( x=> new uye {kid=x.id, kad=x.Kullanici_Ad,ksifre=x.Sifre} ).ToList();

        }

        [WebMethod]
        public List<uye> idyeGore(int id1)
        {
            LoginDBContext ctx = new LoginDBContext();

            return ctx.tbKullanicilers.Where(uye=>uye.id==id1).Select (x => new uye { kid = x.id, kad = x.Kullanici_Ad, ksifre = x.Sifre }).ToList();

        }
    } 
       public class uye
    {
        public int kid { get; set; }
        public string kad { get; set; }
        public string ksifre { get; set; }
    }     
}   


