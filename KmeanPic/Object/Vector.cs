using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    public class Vector
    {
        private List<double> properties = new List<double>();

        public List<double> Properties { get => properties; set => properties = value; }
    }
}
