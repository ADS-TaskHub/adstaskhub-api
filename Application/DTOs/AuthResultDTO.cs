namespace adstaskhub_api.Application.DTOs
{
    public class AuthResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserDTOBase User { get; set; }
        public string Token { get; set; }
    }
}