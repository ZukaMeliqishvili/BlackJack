using System;
using System.Collections.Generic;

namespace BlackJack.DbModels
{
    public partial class User
    {
        public User()
        {
            GameHistories = new HashSet<GameHistory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public decimal? Balance { get; set; } = 0;

        public virtual ICollection<GameHistory> GameHistories { get; set; }
    }
}
