namespace RealEstate_Dapper_UI.Models.JwtModels
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
