using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Fotokonyv2._0
{
    public partial class frmPhotoBookMaster : Form
    {
        //List<PictureBox> pictureBoxList = new List<PictureBox>();
        Point move;

        private Point firstPoint = new Point();
        public int i = 0;

        public frmPhotoBookMaster()
        {
            InitializeComponent();
            trackBarZoom.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewFeltöltött.View = View.Details;
            btnFeltölt.Visible = false;
            listViewFeltöltött.Visible = false;
        }

        //**Új forókönyv gombra kattintás
        int NumberofClick = 0;
        private void btnUj_Click(object sender, EventArgs e)
        {
            btnFeltölt.Visible = false;
            listViewFeltöltött.Visible = false;
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
                    groupBox1.Visible = true;
                    checkBoxA5.Visible = true;
                    checkBoxA4.Visible = true;
                    btnKepMeretOK.Visible = true;
                    cimszoveg.Visible = false;
                    logo.Visible = false;
                    checkBoxA5.Checked = false;
                    checkBoxA4.Checked = false;
                    pbox.Visible = false;
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
                        listViewFeltöltött.Visible = false;
                        groupBox1.Visible = true;
                        checkBoxA5.Visible = true;
                        checkBoxA4.Visible = true;
                        btnKepMeretOK.Visible = true;

                        checkBoxA5.Checked = false;
                        checkBoxA4.Checked = false;

                        pboxOldal1.Visible = false;
                        pboxOldal2.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        btnUjOldal.Visible = false;

                        pbox.Visible = false;
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

        //**Kép feltöltése
        private void populate()
        {
            openFileDialogTallóz.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialogTallóz.Multiselect = true;

            if(openFileDialogTallóz.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                string[] files = openFileDialogTallóz.FileNames;

                int i = 0;
                foreach (var jpegFile in files)
                {
                    try
                    {
                        Bitmap image = new Bitmap(jpegFile);
                        imageListA.Images.Add(image);

                        listViewFeltöltött.LargeImageList = imageListA;
                        listViewFeltöltött.Refresh();
                        listViewFeltöltött.Items.Add(new ListViewItem("", imageListA.Images.Count - 1));
                        this.imageListA.ImageSize = new Size(110, 110);
                        i++;
                    } catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }                    
                }               
           }
        }       
        
        //*Kép behúzása
        private void listViewFeltöltött_ItemActivate(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listViewFeltöltött.SelectedItems)
            {
                int imgIndex = lvi.ImageIndex;
                pbox.Location = Control.MousePosition;
                pbox.Image = this.imageListA.Images[imgIndex];
                pbox.Size = imageListA.ImageSize;
                pbox.Visible = true;
                pbox.BringToFront();
                pbox.MouseDown += (ss, ee) =>
                {
                    if (ee.Button == System.Windows.Forms.MouseButtons.Left) { firstPoint = Control.MousePosition; }
                };

                pbox.MouseMove += (ss, ee) =>
                {
                    if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Point temp = Control.MousePosition;
                        Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                        pbox.Location = new Point(pbox.Location.X - res.X, pbox.Location.Y - res.Y);

                        firstPoint = temp;
                    }
                };
                }
            }

        //void c_MouseDown(object sender, MouseEventArgs e)
        //{
        //    Control c = sender as Control;
        //    isDragging = true;
        //    move = e.Location;
        //}

        //void c_MouseMove(object sender, MouseEventArgs e)
        //{

        //    if (isDragging == true)
        //    {
        //        Control c = sender as Control;
        //        for (int i = 0; i < pictureBoxList.Count(); i++)
        //        {
        //            if (c.Equals(pictureBoxList[i]))
        //            {
        //                pictureBoxList[i].Left += e.X - move.X;
        //                pictureBoxList[i].Top += e.Y - move.Y;
        //            }
        //        }
        //    }
        //}

        //void c_MouseUp(object sender, MouseEventArgs e)
        //{
        //    isDragging = false;
        //}

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
                //pboxOldal1.Size = new Size();

                pboxOldal2.Load(openFileDialogTallóz.FileName);
                //pboxOldal2.Size = new Size();
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

        private void btnKepMeretOK_Click(object sender, EventArgs e)
        {
            if (checkBoxA4.Checked == true || checkBoxA5.Checked == true)
            {
                groupBox1.Visible = false;
                checkBoxA5.Visible = false;
                checkBoxA4.Visible = false;
                btnKepMeretOK.Visible = false;
              
                pboxOldal1.Visible = true;
                pboxOldal1.Size = new System.Drawing.Size(400, 420);
                pboxOldal1.Location = new Point(336, 227);

                pboxOldal2.Visible = true;
                pboxOldal2.Size = new System.Drawing.Size(400, 420);
                pboxOldal2.Location = new Point(756, 227);

                pictureBox1.Location = new Point(274, 437);
                pictureBox2.Location = new Point(1200, 437);
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;

                btnUjOldal.Location = new Point(1175, 600);
                btnUjOldal.Visible = true;

                btnFeltölt.Visible = true;
                listViewFeltöltött.Visible = true;
            }
        }

        private void frmPhotoBookMaster_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        
        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            if (trackBarZoom.Value >= 0)
            {
                pbox.Size = new Size(trackBarZoom.Value, trackBarZoom.Value);
            }
        }

        int kepekSzama = 0;
        private void pbox_KeyUp(object sender, EventArgs e)
        {
            if(pbox.Location.X + pbox.Width > pboxOldal1.Location.X && pbox.Location.Y + pbox.Width > pboxOldal1.Location.Y &&
                pbox.Location.X < pboxOldal1.Location.X + pboxOldal1.Size.Width &&
                pbox.Location.Y < pboxOldal1.Location.Y + pboxOldal1.Size.Height)
            {

                PictureBox pb = new PictureBox
                {
                    Location = pbox.Location,
                    Image = pbox.Image,
                    Size = pbox.Size
                };

                this.Controls.Add(pb);
                pb.Visible = true;
                pb.BringToFront();
                trackBarZoom.Visible = true;
                kepekSzama = kepekSzama + 1;
                
                trackBarZoom.Visible = true;
            } else
            {
                pbox.Visible = false;
            }

            if (pbox.Location.X + pbox.Width > pboxOldal2.Location.X && pbox.Location.Y + pbox.Width > pboxOldal2.Location.Y &&
                pbox.Location.X < pboxOldal2.Location.X + pboxOldal2.Size.Width &&
                pbox.Location.Y < pboxOldal2.Location.Y + pboxOldal2.Size.Height)
            {
                PictureBox pb = new PictureBox
                {
                    Location = pbox.Location,
                    Image = pbox.Image,
                    Size = pbox.Size
                };

                this.Controls.Add(pb);
                pb.Visible = true;
                pb.BringToFront();

                kepekSzama = kepekSzama + 1;

                trackBarZoom.Visible = true;
            }
            else
            {
                pbox.Visible = false;
            }

        }
    }
}
