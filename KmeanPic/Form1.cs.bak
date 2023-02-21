using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KmeanPic
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //Image list 
        List<Picture> PictureList = new List<Picture>();
        string fileName = "C://Users//Admin-s//OneDrive//Máy tính//Study//Khóa luận//KmeanPic//KmeanPic//Resources//FeatureVectors.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                VectorHandle.input(fileName, PictureList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Can't read file" + ex.Message, "Notify", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //listView1.Items.Clear();
            //listView1.View = View.SmallIcon;
            ////tạo danh sách ảnh
            //ImageList listImg = new ImageList() { ImageSize = new Size(70, 70) };
            //listView1.SmallImageList = listImg;
            ////gán cho listView(lst)
            //int k = 0;
            //for (int i = 100; i < 110; i++)
            //{
            //    try
            //    {
            //        listImg.Images.Add(System.Drawing.Image.FromFile("../../Image/beach/" + i + ".jpg"));
            //    }
            //    catch (Exception ex)
            //    {
            //        continue;
            //    }
            //    ListViewItem item = new ListViewItem() { Text = i + ".jpg" };
            //    item.ImageIndex = k++;
            //    listView1.Items.Add(item);
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureEdit1.Image = System.Drawing.Image.FromFile(xtraOpenFileDialog1.FileName);
                textEdit1.Text = xtraOpenFileDialog1.SafeFileName;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foreach (var item in Kmean.kmean(PictureList))
            {
                foreach (var item1 in item.PicturesListOC)
                {
                    richTextBox1.Text += item1.Id + " ";
                }
                richTextBox1.Text += "\n";
            }
        }
    }
}
