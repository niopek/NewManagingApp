using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewManagingApp.Classes
{
    internal class Indeks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Indeks() 
        {
            Name = "";
            Description = "";
        }
    }
}
