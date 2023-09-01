using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheFlag.Shared.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public int Score { get; set; }
    }
}
