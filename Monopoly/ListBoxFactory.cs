using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    abstract class ListBoxFactory
    {
        private List<Box> _boxes = new List<Box>();

        public ListBoxFactory()
        {
            CreateListBoxes();
        }

        public abstract void CreateListBoxes();

        public List<Box> Boxes
        {
            get { return _boxes; }
        }

    }
}
