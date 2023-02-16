namespace MyName.Usr.Application.Contracts.Dtos
{
    public class UserSetRoleDto : InputDto
    {
        public long[] RoleIds { get; set; }
    }
}