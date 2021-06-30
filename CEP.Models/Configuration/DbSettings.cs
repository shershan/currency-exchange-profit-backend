namespace CEP.Models.Configuration
{
    public class DbSettings
    {
        public string DefaultConnection
        {
            get;
            set;
        }

        public int DbPoolSize
        {
            get;
            set;
        }

        public string MigrationAsseblyName
        {
            get;
            set;
        }
    }
}
