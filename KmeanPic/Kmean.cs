using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    class Kmean
    {
        //tạo biến theta
        static double theta = 0;
        //Kmean cải tiến
        public static List<Cluster> kmean(List<Picture> PictureList, List<Cluster> ClusterList)
        {
            //gán theta bằng trung bình các vector
            foreach (var item in PictureList)
            {
                double sum1 = 0;
                foreach (var item1 in item.Vector.Properties)
                {
                    sum1 += item1;
                }
                theta += sum1 / item.Vector.Properties.Count;
            }
            theta /= PictureList.Count;
            //duyệt các ảnh còn lại
            for (int i = 0; i < PictureList.Count; i++)
            {
                //Tạo biến compare lưu lại khoảng cách của các cụm với ảnh thỏa điều kiện
                bool checkNewC = true;
                List<Cluster> compareRadius = new List<Cluster>();
                foreach (var item in ClusterList)
                {
                    double distance = VectorHandle.Distance(PictureList[i].Vector, item.Center);
                    double d = distance - item.Radius;
                    if (d <= theta)
                    {
                        checkNewC = false;
                        compareRadius.Add(new Cluster(new Vector(), d, item.Name));
                    }
                }
                //khởi tạo cụm đầu tiên với vector ảnh đầu tiên
                if (ClusterList.Count < 1)
                {
                    checkNewC = true;
                }
                //thêm cụm mới nếu không có cụm thỏa điều kiện
                if (checkNewC)
                {
                    Cluster clNew = new Cluster(PictureList[i].Vector, theta, i.ToString());
                    clNew.PicturesListOC.Add(PictureList[i]);
                    ClusterList.Add(clNew);
                    PictureList[i].Cluster = i;
                    PictureList[i].Distance = 0;
                }
                else // thêm ảnh vào cụm và gán lại bán kính (bán kính bị giới hạn bằng 2 lần theta ban đầu)
                {
                    Cluster Cmin = compareRadius.Find(cls => cls.Radius == compareRadius.Min(clsm => clsm.Radius));
                    Cluster now = ClusterList.Find(cls => cls.Name.Equals(Cmin.Name));
                    if (Cmin.Radius > 0)
                    {
                        if (now.Radius + Cmin.Radius <= theta * 2)
                            now.Radius += Cmin.Radius;
                    }
                    ClusterList.Find(cls => cls.Name.Equals(Cmin.Name)).PicturesListOC.Add(PictureList[i]);
                    PictureList[i].Cluster = Convert.ToInt32(Cmin.Name);
                    PictureList[i].Distance = now.Radius;
                }
            }

            return ClusterList;
        }

        
    }
}
