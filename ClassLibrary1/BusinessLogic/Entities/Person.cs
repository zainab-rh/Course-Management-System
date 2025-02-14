using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public abstract partial class Person {
        public Person() {}

        public Person(String address, String id, String name, int zipcode):this() {
            this.Address = address;
            this.Id = id;
            this.Name = name;
            this.ZipCode = zipcode;
        }
    }
}
