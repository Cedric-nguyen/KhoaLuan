
namespace KmeanPic
{
    partial class AddR
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddR));
            this.tbxFolderImage = new DevExpress.XtraEditors.TextEdit();
            this.btnChooseImageFolder = new DevExpress.XtraEditors.SimpleButton();
            this.tbxFileTxt = new DevExpress.XtraEditors.TextEdit();
            this.btnChooseTxt = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddResource = new DevExpress.XtraEditors.SimpleButton();
            this.folderImage = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.fileTxt = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.ckAddWithRoot = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFolderImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFileTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAddWithRoot.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxFolderImage
            // 
            this.tbxFolderImage.Enabled = false;
            this.tbxFolderImage.Location = new System.Drawing.Point(37, 35);
            this.tbxFolderImage.Name = "tbxFolderImage";
            this.tbxFolderImage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFolderImage.Properties.Appearance.Options.UseFont = true;
            this.tbxFolderImage.Properties.AutoHeight = false;
            this.tbxFolderImage.Size = new System.Drawing.Size(420, 40);
            this.tbxFolderImage.TabIndex = 21;
            // 
            // btnChooseImageFolder
            // 
            this.btnChooseImageFolder.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImageFolder.Appearance.Options.UseFont = true;
            this.btnChooseImageFolder.Location = new System.Drawing.Point(452, 35);
            this.btnChooseImageFolder.Name = "btnChooseImageFolder";
            this.btnChooseImageFolder.Size = new System.Drawing.Size(168, 40);
            this.btnChooseImageFolder.TabIndex = 20;
            this.btnChooseImageFolder.Text = "Chọn folder hình";
            this.btnChooseImageFolder.Click += new System.EventHandler(this.btnChooseImageFolder_Click);
            // 
            // tbxFileTxt
            // 
            this.tbxFileTxt.Enabled = false;
            this.tbxFileTxt.Location = new System.Drawing.Point(37, 92);
            this.tbxFileTxt.Name = "tbxFileTxt";
            this.tbxFileTxt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFileTxt.Properties.Appearance.Options.UseFont = true;
            this.tbxFileTxt.Properties.AutoHeight = false;
            this.tbxFileTxt.Size = new System.Drawing.Size(420, 40);
            this.tbxFileTxt.TabIndex = 19;
            // 
            // btnChooseTxt
            // 
            this.btnChooseTxt.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseTxt.Appearance.Options.UseFont = true;
            this.btnChooseTxt.Location = new System.Drawing.Point(452, 92);
            this.btnChooseTxt.Name = "btnChooseTxt";
            this.btnChooseTxt.Size = new System.Drawing.Size(168, 40);
            this.btnChooseTxt.TabIndex = 18;
            this.btnChooseTxt.Text = "Chọn file txt";
            this.btnChooseTxt.Click += new System.EventHandler(this.btnChooseTxt_Click);
            // 
            // btnAddResource
            // 
            this.btnAddResource.Appearance.BackColor = System.Drawing.Color.Silver;
            this.btnAddResource.Appearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddResource.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddResource.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnAddResource.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnAddResource.Appearance.Options.UseBackColor = true;
            this.btnAddResource.Appearance.Options.UseBorderColor = true;
            this.btnAddResource.Appearance.Options.UseFont = true;
            this.btnAddResource.Appearance.Options.UseForeColor = true;
            this.btnAddResource.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddResource.ImageOptions.SvgImage")));
            this.btnAddResource.Location = new System.Drawing.Point(424, 155);
            this.btnAddResource.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnAddResource.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(196, 45);
            this.btnAddResource.TabIndex = 17;
            this.btnAddResource.Text = "Thêm tài nguyên";
            this.btnAddResource.Click += new System.EventHandler(this.btnAddResource_Click);
            // 
            // folderImage
            // 
            this.folderImage.DialogStyle = DevExpress.Utils.CommonDialogs.FolderBrowserDialogStyle.Wide;
            this.folderImage.SelectedPath = "folderImage";
            // 
            // fileTxt
            // 
            this.fileTxt.FileName = "fileTxt";
            // 
            // ckAddWithRoot
            // 
            this.ckAddWithRoot.EditValue = true;
            this.ckAddWithRoot.Location = new System.Drawing.Point(37, 165);
            this.ckAddWithRoot.Name = "ckAddWithRoot";
            this.ckAddWithRoot.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAddWithRoot.Properties.Appearance.Options.UseFont = true;
            this.ckAddWithRoot.Properties.Caption = "Thêm root folder";
            this.ckAddWithRoot.Size = new System.Drawing.Size(174, 27);
            this.ckAddWithRoot.TabIndex = 23;
            // 
            // AddR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 240);
            this.Controls.Add(this.ckAddWithRoot);
            this.Controls.Add(this.tbxFolderImage);
            this.Controls.Add(this.btnChooseImageFolder);
            this.Controls.Add(this.tbxFileTxt);
            this.Controls.Add(this.btnChooseTxt);
            this.Controls.Add(this.btnAddResource);
            this.Name = "AddR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.tbxFolderImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFileTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckAddWithRoot.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbxFolderImage;
        private DevExpress.XtraEditors.SimpleButton btnChooseImageFolder;
        private DevExpress.XtraEditors.TextEdit tbxFileTxt;
        private DevExpress.XtraEditors.SimpleButton btnChooseTxt;
        private DevExpress.XtraEditors.SimpleButton btnAddResource;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog folderImage;
        private DevExpress.XtraEditors.XtraOpenFileDialog fileTxt;
        private DevExpress.XtraEditors.CheckEdit ckAddWithRoot;
    }
}
