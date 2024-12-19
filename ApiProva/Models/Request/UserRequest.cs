namespace ApiProva.Models.Request
{
    public class AddUserRequest
    {
        public int? Id { get; set; } = default!;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
    }

    public class UpdateUserRequest
    {
        public int? Id { get; set; } = default!;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
    }

}
