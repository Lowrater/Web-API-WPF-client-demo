using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibary
{
    /// <summary>
    /// The model that matches with the Web API demo person object.
    /// Do not store any other informations if it's not important. Etc. you can use the Id, and Name only if that's the only data you wishes to requests.
    /// </summary>
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}
