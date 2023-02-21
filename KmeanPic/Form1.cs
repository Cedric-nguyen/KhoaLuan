using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KmeanPic
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //khởi tạo các biến
        List<Picture> PictureList = new List<Picture>();
        List<Cluster> ClusterList = new List<Cluster>();
        string fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\Resources\", "FeatureVectors.txt");
        string folder = Path.Combine(Environment.CurrentDirectory, @"..\..\Resources\");

        public Form1()
        {
            InitializeComponent();
        }
        //đọc tài nguyên khi khởi chạy
        private void Form1_Load(object sender, EventArgs e)
        {
            if(Directory.EnumerateFileSystemEntries(folder + "/Image/").Any())
            {
                try
                {
                    //var watch = System.Diagnostics.Stopwatch.StartNew();

                    //Nhận tài nguyên ảnh
                    VectorHandle.input(fileName, PictureList);
                    //Gom cụm tài nguyên nếu chưa có file cụm
                    if (!Directory.EnumerateFileSystemEntries(folder + "/Cluster/").Any())
                    {
                        //watch.Restart();
                        ClusterList = Kmean.kmean(PictureList, ClusterList);
                        //watch.Stop();

                        VectorHandle.outputCluster(ClusterList, folder + "/Cluster/");
                    }
                    //đọc danh sách cụm có sẳn
                    else
                    {
                        ClusterList = ClusterHandle.ReadAllCluster(folder + "/Cluster/");
                    }
                    //label4.Text = (watch.ElapsedMilliseconds / 1000.0).ToString() + "s";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Can't read file" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
            else
            {
                MessageBox.Show("Notify: Don't have image" , "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Chọn ảnh tìm kiếm
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            if (fileImage.ShowDialog() == DialogResult.OK)
            {
                pictureEdit1.Image = System.Drawing.Image.FromFile(fileImage.FileName);
                tbxSearchImage.Text = fileImage.SafeFileName;
                btnSearch.Enabled = true;
            }
        }
        //Tìm kiếm ảnh
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                search(fileImage.SafeFileName, listView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void search(string fileName, ListView lst)
        {
            //bắt đầu đếm giờ
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //Lấy picture từ file name
            Picture pic = PictureList.Find(picture => picture.ImgName.Equals(fileName));

            //lấy danh sách tìm kiếm
            List<Picture> listSearch = new List<Picture>();
            listSearch = ClusterHandle.getSearchData(pic, listSearch,ClusterList);

            //thông báo lỗi nếu danh sách tìm kiếm rỗng
            if (listSearch.Count < 1)
            {
                MessageBox.Show("Error: Search fail!!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //custom cho listview
            lst.Items.Clear();
            lst.View = View.SmallIcon;
            ImageList listImg = new ImageList() { ImageSize = new Size(200, 200) };
            lst.SmallImageList = listImg;

            //thêm ảnh vào list
            int Index = 0;
            double sumTrue = 0;
            foreach (Picture image in listSearch)
            {
                if (image.FolderName.Equals(pic.FolderName))
                    sumTrue++;
                listImg.Images.Add(Image.FromFile(folder + "Image/" + image.FolderName + "/" + image.ImgName));
                ListViewItem item = new ListViewItem() { Text = image.ImgName };
                item.ImageIndex = Index++;
                lst.Items.Add(item);

            }

            //xuất các thông số tìm kiếm
            int sumExpectPic = PictureList.FindAll(x => x.FolderName == pic.FolderName).ToList().Count;
            double DCX = (sumTrue / listSearch.Count()) * 100; //hình trong listview
            double DP = (sumTrue / sumExpectPic) * 100; //tổng hình
            label1.Text = DCX.ToString() + "%";
            label3.Text = DP.ToString() + "%";
            label2.Text = (2 * ((DCX * DP) / (DCX + DP))).ToString() + "%";
            label5.Text = lst.Items.Count.ToString();

            //dùng đếm giờ và xuất thời gian chạy
            watch.Stop();
            label4.Text = (watch.ElapsedMilliseconds / 1000.0).ToString() + "s";
        }
        

        //Thêm tài nguyên ảnh
        private void btnMenuAddR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddR add = new AddR(PictureList, ClusterList,folder);
            add.Show();
        }

        private void btnClearC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(folder + "/Cluster/");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                MessageBox.Show("Info: Clear success" , "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                MessageBox.Show("Error: Can't Clear file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                File.WriteAllText(fileName, string.Empty);
                System.IO.DirectoryInfo di = new DirectoryInfo(folder + "/Image/");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                ClusterList.Clear();
                PictureList.Clear();
                btnClearC_ItemClick(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Can't Clear file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnClustering_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Directory.EnumerateFileSystemEntries(folder + "/Cluster/").Any())
            {
                VectorHandle.input(fileName, PictureList);
                ClusterList = Kmean.kmean(PictureList, ClusterList);
                VectorHandle.outputCluster(ClusterList, folder + "/Cluster/");
                MessageBox.Show("Info: Run Kmean success", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
