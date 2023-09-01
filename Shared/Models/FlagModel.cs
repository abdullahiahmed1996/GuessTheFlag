using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheFlag.Shared.Models
{
    public class FlagModel
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public CountryModel Country { get; set; }
    }
}
