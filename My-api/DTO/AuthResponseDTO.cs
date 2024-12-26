namespace My_api.DTO
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
