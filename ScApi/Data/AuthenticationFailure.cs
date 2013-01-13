namespace ScApi.Data
{
    public class AuthenticationFailure
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public bool SignupAllowed { get; set; }
    }
}