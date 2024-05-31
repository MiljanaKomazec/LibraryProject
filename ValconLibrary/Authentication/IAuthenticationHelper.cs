namespace ValconLibrary.Authentication
{
    public interface IAuthenticationHelper
    {
        public bool AuthenticationPrincipal(Principal principal);
        public string GenerateJwt(Principal principal);
    }
}
