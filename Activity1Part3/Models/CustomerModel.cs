using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1Part3.Models
{
    public class CustomerModel
    {
        public CustomerModel(int ID, string Name, int Age)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}