namespace RealEstate_Dapper_Api.Dtos.AppUserDtos
{
    public class ResultAppUserDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}
