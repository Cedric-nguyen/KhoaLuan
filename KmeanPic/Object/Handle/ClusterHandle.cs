using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KmeanPic
{
    class ClusterHandle
    {
        //đọc file txt để lấy các cụm đã gom
        public static List<Cluster> ReadAllCluster(string foldername)
        {
            List<Cluster> ClusterList = new List<Cluster>();
            int Clusters = Directory.GetFiles(foldername,"*.txt").Length;
            //đọc các cụm trong thư mục
            for (int file = 0; file < Clusters; file++)
            {
                var ClusterStr = File.ReadAllLines(foldername + file + ".txt");
                //đọc thông tin các cụm
                Cluster cls = readCluster(ClusterStr, file.ToString());
                ClusterList.Add(cls);
            }
            return ClusterList;
        }
        //lấy thông tin cụm từ file txt
        private static Cluster readCluster(string[] ClusterStr, string fileName)
        {
           
            Cluster cls = new Cluster();
            List<Picture> PL = new List<Picture>();
            cls.Name = fileName;
            bool first = true;
            //tách thông tin từ chuỗi
            foreach (var picture in ClusterStr)
            {
                if (first)
                {
                    cls.Radius = Convert.ToDouble(picture);
                    first = false;
                    continue;
                }

                Picture Pic = new Picture();
                Vector vector = new Vector();
                var str = picture.Trim().Split(' ', '(', ')');
                for (int i = 2; i < str.Length - 2; i++)
                {
                    if (str[i] != "")
                    {
                        if (str[i].Contains(".jpg"))
                        {
                            Pic.ImgName = str[i];
                            break;
                        }
                        vector.Properties.Add(Double.Parse(str[i]));
                    }
                }
                Pic.Id = str[0];
                Pic.Vector = vector;
                Pic.FolderName = str[str.Length - 2];
                PL.Add(Pic);
            }
            cls.PicturesListOC = PL;
            cls.Center = cls.PicturesListOC[0].Vector;
            return cls;
        }
        //Tìm các ảnh tương tự ảnh đưa vào
        public static List<Picture> getSearchData(Picture pic, List<Picture> listSearch, List<Cluster> ClusterList)
        {
            //tính khoản cách tối thiểu  lấy danh sách hình trong khoản cách tối thiểu
            double absDistance = 0;
            foreach (var item in ClusterList)
            {
                absDistance += VectorHandle.Distance(pic.Vector, item.Center);
            }
            absDistance = (absDistance / ClusterList.Count) * 0.7;

            //lấy danh sách các cụm dựa vào khoản cách tối thiểu
            List<Cluster> cluster = new List<Cluster>();
            cluster = getCLuster(pic, absDistance, ClusterList);

            //lấy danh sách tìm kiếm
            foreach (var item in cluster)
            {
                listSearch = getListSer(pic, listSearch, item.Name, ClusterList);
            }
            //sắp xếp lại danh sách theo khoảng cách giảm dần với ảnh
            listSearch = listSearch.OrderBy(p => p.Distance).ToList();

            return listSearch;
        }

        //Lấy danh sách các cụm trong khoản cách tối thiểu
        private static List<Cluster> getCLuster(Picture pic, double absDistance, List<Cluster> ClusterList)
        {
            List<Cluster> newClsList = new List<Cluster>();
            foreach (var cluster in ClusterList)
            {
                double distance = VectorHandle.Distance(cluster.Center, pic.Vector);
                if (distance <= absDistance)
                    newClsList.Add(cluster);
            }
            return newClsList;
        }

        //Lấy danh sách các ảnh trong cụm
        private static List<Picture> getListSer(Picture pic, List<Picture> listSearch, string clusterName, List<Cluster> ClusterList)
        {
            Cluster cls = ClusterList.Find(C => C.Name == clusterName);
            foreach (var item in cls.PicturesListOC)
            {
                item.Distance = VectorHandle.Distance(pic.Vector, item.Vector);
                listSearch.Add(item);
            }
            return listSearch;
        }
    }

}