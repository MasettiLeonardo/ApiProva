namespace ApiProva.Database
{
    public sealed class FakeDatabase
    {
        public List<User> Users { get; set; }

        public FakeDatabase()
        {
            Users = [];

            Users.Add(new User { Id = 1, Name = "Mario", Surname = "Rossi", Email = "mario.rossi@example.com" });
            Users.Add(new User { Id = 2, Name = "Luigi", Surname = "Bianchi", Email = "luigi.bianchi@example.com" });
            Users.Add(new User { Id = 3, Name = "Anna", Surname = "Verdi", Email = "anna.verdi@example.com" });
            Users.Add(new User { Id = 4, Name = "Paolo", Surname = "Neri", Email = "paolo.neri@example.com" });
            Users.Add(new User { Id = 5, Name = "Giulia", Surname = "Gialli", Email = "giulia.gialli@example.com" });
        }

    }

    public class User
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

}
