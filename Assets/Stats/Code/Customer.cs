using SQLite;

namespace Stats.Code
{
    public class Customer
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [MaxLength (64)]
        public string FirstName { get; set; }

        [MaxLength (64)]
        public string LastName { get; set; }

        [MaxLength (64), Indexed]
        public string Email { get; set; }
    }
}