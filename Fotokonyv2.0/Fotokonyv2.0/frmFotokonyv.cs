using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Fotokonyv2._0
{
    public partial class frmPhotoBookMaster : Form
    {
        Image imgOriginal;

        public frmPhotoBookMaster()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewFeltöltött.View = View.Details;
            //listViewFeltöltött.Columns.Add("asd", 150);
            //listViewFeltöltött.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //**Új forókönyv gombra kattintás
        int NumberofClick = 0;
        private void btnUj_Click(object sender, EventArgs e)
        {
            ++NumberofClick;
            switch(NumberofClick)
            {
                case 1:
                    btnHatter.Visible = true;
                    btnHatterKep.Visible = true;
                    btnKepcim.Visible = true;
                    btnKepleiras.Visible = true;
                    btnSzovBuborek.Visible = true;
                    btnSablonok.Visible = true;
                    btnFeltölt.Visible = true;
                    listViewFeltöltött.Visible = true;
                    groupBox1.Visible = true;
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    button1.Visible = true;
                    cimszoveg.Visible = false;
                    logo.Visible = false;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    break;
                default:
                    DialogResult confirm = MessageBox.Show("Biztosan új fotókönyvet akarsz nyitni?", "Új fotókönyv", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        pboxOldal1.BackColor = Color.White;
                        pboxOldal1.InitialImage = null;
                        pboxOldal2.BackColor = Color.White;
                        pboxOldal2.InitialImage = null;
                        pboxOldal1.Image = null;
                        pboxOldal2.Image = null;
                        listViewFeltöltött.Items.Clear();
                        btnHatter.Visible = true;
                        btnHatterKep.Visible = true;
                        btnKepcim.Visible = true;
                        btnKepleiras.Visible = true;
                        btnSzovBuborek.Visible = true;
                        btnSablonok.Visible = true;
                        btnFeltölt.Visible = true;
                        listViewFeltöltött.Visible = true;
                        groupBox1.Visible = true;
                        checkBox1.Visible = true;
                        checkBox2.Visible = true;
                        button1.Visible = true;

                        checkBox1.Checked = false;
                        checkBox2.Checked = false;

                        pboxOldal1.Visible = false;
                        pboxOldal2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        btnUjOldal.Visible = false;
                    }
                    break;
    

            }

           
           
        }

        //**Mentés gombra kattintás
        private void btnMentés_Click(object sender, EventArgs e)
        {

        }

        //**Kilépés gombra kattintás
        private void btnKilépés_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Biztosan ki akarsz lépni?", "Kilépés", MessageBoxButtons.YesNo);
            if(confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //**Help gombra kattintás
        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp settingsForm = new frmHelp();
            settingsForm.Show();
           
        }

        private void populate()
        {
            //ImageList imgs = new ImageList();
            //imgs.ImageSize = new Size(80, 80);

            //string[] paths = { };
            //paths = Directory.GetFiles("C:/Users/bagyu/Pictures/foto");

            //try
            //{
            //    foreach(String p in paths)
            //    {
            //        imgs.Images.Add(Image.FromFile(p));
            //    }
            //} catch(Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}

            //listViewFeltöltött.SmallImageList = imgs;
            //ListViewItem item = new ListViewItem();
            //listViewFeltöltött.Items.Add("white.jpg", 0);
            ////listViewFeltöltött.Items.Add("black.jpg", 1);
            ////listViewFeltöltött.Items.Add("red.jpg", 2);
            ////listViewFeltöltött.Items.Add("blue.jpg", 3);
            ////listViewFeltöltött.Items.Add("pink.jpg", 0);


            openFileDialogTallóz.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialogTallóz.Multiselect = true;

            if(openFileDialogTallóz.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = openFileDialogTallóz.FileNames;
                foreach(var jpegFile in files)
                {
                    try
                    {
                        Bitmap image = new Bitmap(jpegFile);
                        imageListA.Images.Add(image);
                    } catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    listViewFeltöltött.LargeImageList = imageListA;
                    listViewFeltöltött.Refresh();
                }

                listViewFeltöltött.Items.Add(new ListViewItem("", imageListA.Images.Count-1));
                this.imageListA.ImageSize = new Size(110, 110);
            } 



            //DirectoryInfo dir = new DirectoryInfo(@"C:/Users/bagyu/Pictures/foto");
            //foreach(FileInfo file in dir.GetFiles())
            //{   
            //    try
            //    {
            //        this.imageListA.Images.Add(Image.FromFile(file.FullName));
            //    } catch
            //    {
            //        MessageBox.Show("Not image file");
            //    }
            //}
            //this.listViewFeltöltött.View = View.LargeIcon;
            //this.imageListA.ImageSize = new Size(90, 90);
            //this.listViewFeltöltött.LargeImageList = this.imageListA;

            //for(int j = 0; j < this.imageListA.Images.Count; j++)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.ImageIndex = j;
            //    this.listViewFeltöltött.Items.Add(item);
            //}
        }

        //**Feltöltés gombra kattintás
        private void btnFeltölt_Click(object sender, EventArgs e)
        {
            populate();
        }

        //**Háttérszín gombra kattintás
        private void btnHatter_Click(object sender, EventArgs e)
        {
            pboxOldal1.Image = null;
            pboxOldal2.Image = null;
            colorDialogHatter.ShowDialog();
            pboxOldal1.BackColor = colorDialogHatter.Color;
            pboxOldal2.BackColor = colorDialogHatter.Color;
            
        }

        //**Háttérkép gombra kattintás
        private void btnHatterKep_Click(object sender, EventArgs e)
        {
            openFileDialogTallóz.Filter = "(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialogTallóz.Multiselect = false;
            pboxOldal1.BackColor = Color.White;
            pboxOldal2.BackColor = Color.White;
            if (openFileDialogTallóz.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pboxOldal1.Load(openFileDialogTallóz.FileName);
                imgOriginal = pboxOldal1.Image;

                pboxOldal2.Load(openFileDialogTallóz.FileName);
                if (pboxOldal1.Image != null)
                {
                    pboxOldal1.Image = Zoom2(imgOriginal);
                }
            }
            
            

        }

        //**Képcím gombra kattintás
        private void btnKepcim_Click(object sender, EventArgs e)
        {

        }

        //**Képleírás gombra kattintás
        private void btnKepleiras_Click(object sender, EventArgs e)
        {

        }

        //**Szövegbuborék gombra kattintás
        private void btnSzovBuborek_Click(object sender, EventArgs e)
        {

        }

        //**Sablonok gombra kattintás
        private void btnSablonok_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                groupBox1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                button1.Visible = false;
                pboxOldal1.Size = new System.Drawing.Size(300, 320);
                pboxOldal1.Visible = true;
                pboxOldal2.Size = new System.Drawing.Size(300, 320);
                pboxOldal2.Location = new Point(656, 227);
                pboxOldal2.Visible = true;
                pictureBox1.Location = new Point(274, 376);
                pictureBox2.Location = new Point(1000, 376);
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;

                btnUjOldal.Location = new Point(976, 497);
                btnUjOldal.Visible = true;

            }
            if (checkBox2.Checked == true)
            {
                groupBox1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                button1.Visible = false;
                pboxOldal1.Size = new System.Drawing.Size(400, 420);

                pboxOldal1.Visible = true;
                pboxOldal2.Size = new System.Drawing.Size(400, 420);
                pboxOldal2.Location = new Point(756, 227);
                pboxOldal2.Visible = true;

                pictureBox1.Location = new Point(274, 437);
                pictureBox2.Location = new Point(1200, 437);
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;

                btnUjOldal.Location = new Point(1175, 600);
                btnUjOldal.Visible = true;
            }
         

            
        }

        private void frmPhotoBookMaster_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        Image Zoom2(Image img)
        {
            Bitmap vmi = new Bitmap(img, 300, 320);
            Graphics g = Graphics.FromImage(vmi);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return vmi;
        }
        Image Zoom(Image img, Size size)
        {
            Bitmap vmi = new Bitmap(img, 300 + (img.Width * size.Width / 100), 320 + (img.Height * size.Height / 100));
            Graphics g = Graphics.FromImage(vmi);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return vmi;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value >= 0)
            {

                pboxOldal1.Image = Zoom(imgOriginal, new Size(trackBar1.Value, trackBar1.Value));
            }
        }
 

    }
}
