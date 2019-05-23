namespace CheckIT.API.Dtos
{
    public class UserDto
    {   
        public int Id { get; set; }
        public string Username { get; set; }
        public int PermissionLevel { get; set; }
        public int realmID { get; set; }
        public bool MainAdmin { get; set ; }
    }
}