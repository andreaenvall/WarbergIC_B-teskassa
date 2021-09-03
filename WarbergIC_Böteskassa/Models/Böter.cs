using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarbergIC_Böteskassa.Models
{
    public class Böter
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public Regler Åtalspunkt { get; set; }
        public Person Åtalad { get; set; }
        public string Kommentar { get; set; }

    }
}
