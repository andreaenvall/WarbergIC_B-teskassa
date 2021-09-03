using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarbergIC_Böteskassa.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Nummer { get; set; }

        public string ImgUrl { get; set; }

        public ICollection<Böter> Böteslista { get; set; }
    }
}
