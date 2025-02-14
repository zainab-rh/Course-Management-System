using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Person {
        public String Address { get; set; }
        public String Id { get; set; }
        public String Name { get; set; }
        public int ZipCode { get; set; }

    }
}
