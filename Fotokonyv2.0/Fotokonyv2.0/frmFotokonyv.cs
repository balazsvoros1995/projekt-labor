﻿using System;
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
            init();
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

        private Point firstPoint = new Point();

        private void populate()
        {
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
        }

        public void init()
        {
            Panel moveObj = new Panel();
            Point p = listViewFeltöltött.PointToClient(MousePosition);
            //moveObj = listViewFeltöltött.HitTest(p);
            pictureBox1.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left) { firstPoint = Control.MousePosition; }
            };

            pictureBox1.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    pictureBox1.Location = new Point(pictureBox1.Location.X - res.X, pictureBox1.Location.Y - res.Y);

                    firstPoint = temp;
                }
            };
        }

        private void listViewFeltöltött_Click(object sender, EventArgs e)
        {
        //    foreach(ListViewItem lvi in listViewFeltöltött.SelectedItems)
        //    {
        //        if(lvi.Index > 0)
        //        {
        //            //MessageBox.Show("asd");
        //            Panel moveObj = new Panel();
        //            listViewFeltöltött.MouseDown += (ss, ee) =>
        //            {
        //                if (ee.Button == System.Windows.Forms.MouseButtons.Left) { firstPoint = Control.MousePosition; }
        //            };

        //            listViewFeltöltött.MouseMove += (ss, ee) =>
        //            {
        //                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
        //                {
        //                    Point temp = Control.MousePosition;
        //                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

        //                    listViewFeltöltött.Location = new Point(listViewFeltöltött.Location.X - res.X, listViewFeltöltött.Location.Y - res.Y);

        //                    firstPoint = temp;
        //                }
        //            };

        //        }
        //    }
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
