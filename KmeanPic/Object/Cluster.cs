using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    public class Cluster
    {
        private string name;
        private Vector center;
        private double radius;
        private List<Picture> picturesListOC;

        public Cluster()
        {
        }
        public Cluster(Vector center, double radius, List<Picture> picturesListOC1, string name)
        {
            this.name = name;
            this.center = center;
            this.radius = radius;
            PicturesListOC = picturesListOC1;
        }
        public Cluster(Vector center, double radius, string name)
        {
            this.name = name;
            this.center = center;
            this.radius = radius;
            PicturesListOC = new List<Picture>();
        }

        internal Vector Center { get => center; set => center = value; }
        internal List<Picture> PicturesListOC { get => picturesListOC; set => picturesListOC = value; }
        public string Name { get => name; set => name = value; }
        public double Radius { get => radius; set => radius = value; }
    }
}
