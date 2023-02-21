using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KmeanPic
{
    public partial class AddR : DevExpress.XtraEditors.XtraDialogForm
    {
        //khỏi tạo biến
        string folder = Path.Combine(Environment.CurrentDirectory, @"..\..\Resources\");
        List<Picture> PictureList = new List<Picture>();
        List<Cluster> ClusterList = new List<Cluster>();
        //hàm khỏi tạo kèm danh sách ảnh và cụm
        public AddR(List<Picture> PictureList, List<Cluster> ClusterList, string folder)
        {
            this.PictureList = PictureList;
            this.ClusterList = ClusterList;
            this.folder = folder;
            InitializeComponent();
        }
        //thêm tài nguyên ảnh
        private void btnAddResource_Click(object sender, EventArgs e)
        {
            if(tbxFileTxt.Text.Length > 0 && tbxFolderImage.Text.Length > 0)
            {
                //Lưu folder hình 
                string sourcePath = folderImage.SelectedPath;
                string targetPath = folder + "Image";
                if (System.IO.Directory.Exists(sourcePath))
                {
                    if(ckAddWithRoot.Checked)
                    {
                        targetPath = targetPath + @"\" + Path.GetFileName(sourcePath);
                        Directory.CreateDirectory(targetPath);
                    }
                    foreach (var dirPath in Directory.GetDirectories(sourcePath))
                    {
                        Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                    }
                    foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }
                    MessageBox.Show("Notify: Add success!!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Đọc file txt 
                List<Picture> NewPictureList = new List<Picture>();
                VectorHandle.input(fileTxt.FileName, NewPictureList);
                foreach (var item in NewPictureList)
                {
                    if (!PictureList.Exists(x => x.ImgName == item.ImgName))
                    {
                        item.Id = PictureList.Count.ToString();
                        PictureList.Add(item);
                    }
                    else NewPictureList.Remove(item);
                }
                //gọm cụm các tài nguyên mới, xuất file cụm và chèn lại file txt nguồn
                VectorHandle.outputVector(PictureList, folder);
                ClusterList = Kmean.kmean(NewPictureList, ClusterList);
                VectorHandle.outputCluster(ClusterList, folder + "/Cluster/");
            }
            else
            {
                MessageBox.Show("Error: Vui lòng đưa vào đủ folder và txt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //chọn folder chứa ảnh
        private void btnChooseImageFolder_Click(object sender, EventArgs e)
        {
            if (folderImage.ShowDialog() == DialogResult.OK)
            {
                tbxFolderImage.Text = folderImage.SelectedPath;
            }
        }
        //chọn file txt chứa các đặc điểm
        private void btnChooseTxt_Click(object sender, EventArgs e)
        {
            if (fileTxt.ShowDialog() == DialogResult.OK)
            {
                tbxFileTxt.Text = fileTxt.SafeFileName;
            }
        }
    }
}
