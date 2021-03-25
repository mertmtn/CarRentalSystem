using System; 

namespace Core.Utilities.Security.JsonWebToken
{
    //Erişim anahtarı
    public class AccessToken
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
