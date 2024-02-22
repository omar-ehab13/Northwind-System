namespace Northwind.Core.Helpers.Auth
{
    public class EmailConfig
    {
        public int Port { get; set; }
        public string? Host { get; set; }
        public string? FromEmail { get; set; }
        public string? Password { get; set; }
    }
}
