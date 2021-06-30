namespace CEP.WebAPI.Models
{
    public class AccessTokenModel
    {
        public AccessTokenModel(string token)
        {
            AccessToken = token;
        }

        public string AccessToken
        {
            get;
            set;
        }
    }
}
