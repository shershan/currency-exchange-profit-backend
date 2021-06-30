namespace CEP.Models.Configuration
{
    public class JwtSettings
    {   
        public string Issuer
        {
            get;
            set;
        }

        public string Audience
        {
            get;
            set;
        }

        public string SigningKey
        {
            get;
            set;
        }
    }
}
