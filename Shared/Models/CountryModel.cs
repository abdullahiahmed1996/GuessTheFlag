using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheFlag.Shared.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public FlagModel Flag { get; set; }
    }
}
