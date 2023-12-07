namespace IntroSEProject.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiryDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }
    }
}
