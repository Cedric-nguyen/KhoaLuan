using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeanPic
{
    class VectorHandle
    {
        //đọc file  
        public static void input(string fileName, List<Picture> listItem)
        {
            //xóa ds ban đầu và đọc file vào chuỗi
            listItem.Clear();
            var strs = File.ReadAllLines(fileName);
            //lấy thông tin ảnh từ chuỗi
            int id = 0;
            foreach (var str in strs)
            {
                Picture img = new Picture();
                Vector vt = new Vector();
               
                var vector = str.Trim().Split(' ', '(', ')');
                img.Id = id++.ToString();
                
                for (int i = 1; i < vector.Length - 2; i++)
                {
                    if (vector[i].Contains(".jpg"))
                        img.ImgName = vector[i];
                    else if (Double.TryParse(vector[i], out double v))
                        vt.Properties.Add(v);
                }
                img.Vector = vt;
                
                img.FolderName = vector[vector.Length - 2];
                listItem.Add(img);
            }
        }
        //xuất các cụm theo định dạng txt
        public static void outputCluster(List<Cluster> ClusterList, string folderName)
        {
            //sắp xếp lại thứ tự ảnh theo khoảng cách với tâm cụm và gán tên file
            int index = 0;
            foreach (var cluster in ClusterList)
            {
                cluster.PicturesListOC = cluster.PicturesListOC.OrderBy(clus => clus.Distance).ToList();
                cluster.Name = (index++).ToString();
            }
            //xuất các cụm thành từng file txt
            foreach (var cluster in ClusterList)
            {
                string pictureString = String.Empty;
                pictureString += cluster.Radius + "\n";
                foreach (var picture in cluster.PicturesListOC)
                {
                    pictureString += picture.Id + " (";
                    foreach (var property in picture.Vector.Properties)
                    {
                        pictureString += property + " ";
                    }
                    pictureString = pictureString.Substring(0, pictureString.Length - 1);
                    pictureString += ") (" + picture.ImgName + ") (" + picture.FolderName + ")\n";
                }
                pictureString = pictureString.Substring(0, pictureString.Length - 1);
                File.WriteAllText(folderName + cluster.Name + ".txt", pictureString);
            }
        }
        //xuất lại file đặc điểm khi thêm tài nguyên
        public static void outputVector(List<Picture> PictureList, string folderName)
        {
            string pictureString = String.Empty;
            foreach (var picture in PictureList)
            {
                pictureString += picture.Id + " (";
                foreach (var property in picture.Vector.Properties)
                {
                    pictureString += property + " ";
                }
                pictureString = pictureString.Substring(0, pictureString.Length - 1);
                pictureString += " ) (" + picture.ImgName + ") (" + picture.FolderName + ")\n";
            }
            pictureString = pictureString.Substring(0, pictureString.Length - 1);
            File.WriteAllText(folderName + "FeatureVectors.txt", pictureString);
        }
        //hàm tính khoảng cách giữa các vector
        public static double Distance(Vector a, Vector b)
        {
            double sum = 0;
            for (int i = 0; i < a.Properties.Count; i++)
                sum += Math.Pow((a.Properties[i] - b.Properties[i]), 2.0);
            return Math.Sqrt(sum);
        }
        //public static double Distance(Vector a, Vector b)
        //{
        //    double sum = 0;
        //    for (int i = 0; i < a.Properties.Count; i++)
        //        sum += Math.Abs(a.Properties[i] - b.Properties[i]);
        //    //sum += Math.Pow((a.Properties[i] - b.Properties[i]),2.0);
        //    return /*Math.Sqrt(sum)/44*/sum / 44;
        //}
    }
}
