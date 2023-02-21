using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    public class Picture
    {
        private string id, imgName, folderName;
        private Vector vector;
        private int cluster;
        private double distance;
        //Contructor
        public Picture()
        {
            vector = new Vector();
            id = imgName = folderName = String.Empty;
            cluster = -1;
            distance = -1;
        }

        public string Id { get => id; set => id = value; }
        public string ImgName { get => imgName; set => imgName = value; }
        public string FolderName { get => folderName; set => folderName = value; }
        internal Vector Vector { get => vector; set => vector = value; }
        public int Cluster { get => cluster; set => cluster = value; }
        public double Distance { get => distance; set => distance = value; }
    }
}
