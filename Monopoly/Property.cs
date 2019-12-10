using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Property
    {
        string name;
        int property_value;

        public Property(string name, int property_value)
        {
            this.name = name;
            this.property_value = property_value;

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Property_value
        {
            get { return property_value; }
            set { property_value = value; }

        }
    }
}
