using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Model
{
    public class Adult
    {
        public String Job { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Sex { get; set; }
        public String HairColour { get; set; }
        public String EyeColour { get; set; }
        public int Age { get; set; }
        public void UpdatePerson(Person toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColour = toUpdate.HairColour;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColour = toUpdate.EyeColour;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }
    }
}
