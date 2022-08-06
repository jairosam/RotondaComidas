namespace APIRotonda.DTO.Users
{
    public class AuthenticationResponse
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
