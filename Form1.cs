using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andmebaas_Vsevolod_Tsarev_TARpv23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            NaitaLaod();
        }

        // Meetod andmebaasi ühenduse saamiseks
        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Andmebaas_Vsevolod_Tsarev_TARpv23\Andmed.mdf;Integrated Security=True");
        }

        // Vea töötlemise meetod
        private void HandleError(Exception ex)
        {
            if (ex is SqlException)
            {
                MessageBox.Show("SQL viga: " + ex.Message);
            }
            else if (ex is IOException)
            {
                MessageBox.Show("Viga faili töötlemisel: " + ex.Message);
            }
            else
            {
                MessageBox.Show("Tundmatu viga: " + ex.Message);
            }
        }

        // Üldine meetod SQL päringute täitmiseks
        private DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                cmd = new SqlCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable laotable;

        // Meetod, mis kuvab kõik tooted
        public void NaitaAndmed()
        {
            DataTable dt = ExecuteQuery("SELECT * FROM Toode");
            dataGridView1.DataSource = dt;
        }

        // Meetod, mis kuvab kõik laod
        private void NaitaLaod()
        {
            DataTable dt = ExecuteQuery("SELECT Id, LaoNimetus FROM Ladu");
            foreach (DataRow item in dt.Rows)
            {
                ladu_cb.Items.Add(item["LaoNimetus"].ToString());
            }
        }

        int ID = 0;

        // Meetod, mis käsitleb andmete valimist DataGridView'st
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            Nimetus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Nimetus"].Value.ToString();
            Kogus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Kogus"].Value.ToString();
            Hind_txt.Text = dataGridView1.Rows[e.RowIndex].Cells["Hind"].Value.ToString();

            try
            {
                string imagePath = Path.Combine(Path.GetFullPath(@"..\..\Pildid"), dataGridView1.Rows[e.RowIndex].Cells["pilt"].Value.ToString());
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(fs);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\Pildid"), "pilt.png"));
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void Lisa_btn_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty && Kogus_txt.Text.Trim() != string.Empty && Hind_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    using (var conn = GetConnection())
                    {
                        conn.Open();

                        cmd = new SqlCommand("SELECT Id FROM Ladu WHERE LaoNimetus=@ladu", conn);
                        cmd.Parameters.AddWithValue("@ladu", ladu_cb.Text);
                        int laduId = Convert.ToInt32(cmd.ExecuteScalar());

                        string imagePath = Path.Combine(Path.GetFullPath(@"..\..\Pildid"), Nimetus_txt.Text + Path.GetExtension(open.FileName));
                        byte[] imageData = File.ReadAllBytes(open.FileName);

                        cmd = new SqlCommand("INSERT INTO Toode(Nimetus, Kogus, Hind, toodepilt, LaoId) VALUES (@toode, @kogus, @hind, @toodepilt, @laduId)", conn);
                        cmd.Parameters.AddWithValue("@toode", Nimetus_txt.Text);
                        cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                        cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                        cmd.Parameters.AddWithValue("@toodepilt", imageData);
                        cmd.Parameters.AddWithValue("@laduId", laduId);

                        cmd.ExecuteNonQuery();
                    }
                    NaitaAndmed();
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik andmed!");
            }
        }


        private void Eemaldamine()
        {
            MessageBox.Show("Andmed on edukalt uuendatud", "Uuendamine");
            Nimetus_txt.Text = "";
            Kogus_txt.Text = "";
            Hind_txt.Text = "";
            pictureBox1.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"..\..\Pildid"), "pilt.png"));
        }

        OpenFileDialog open;
        SaveFileDialog save;

        // Meetod pildi valimiseks
        private void otsipilt_btn_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\Pictures\";
            open.Multiselect = false;
            open.Filter = "Pildi failid (*.jpeg; *.png; *.bmp; *.jpg)|*.jpeg; *.png; *.bmp; *.jpg";

            if (open.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(Nimetus_txt.Text))
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\Pildid");
                save.FileName = Nimetus_txt.Text + Path.GetExtension(open.FileName);
                save.Filter = "Pildid |" + Path.GetExtension(open.FileName);

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName);
                    pictureBox1.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Sisesta toote nimi või vajuta 'Tühista'");
            }
        }

        // Meetod toote kustutamiseks
        private void kustuta_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                if (ID != 0)
                {
                    using (var conn = GetConnection())
                    {
                        conn.Open();
                        cmd = new SqlCommand("DELETE FROM Toode WHERE Id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                    }

                    // Kustutame pildi alles pärast andmete kustutamist andmebaasist
                    string file = Nimetus_txt.Text;
                    Kustuta_fail(file);
                    Eemaldamine();
                    NaitaAndmed();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Viga kustutamisel!");
            }
        }

        // Meetod faili kustutamiseks
        private void Kustuta_fail(string file)
        {
            try
            {
                string filePath = Path.Combine(Path.GetFullPath(@"..\..\Pildid"), file);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    MessageBox.Show($"Fail {filePath} on edukalt kustutatud.");
                }
                else
                {
                    MessageBox.Show("Faili ei leitud.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Viga faili kustutamisel: {ex.Message}");
            }
        }

        // Meetod toote uuendamiseks
        private void Uuenda_btn_Click(object sender, EventArgs e)
        {
            if (Nimetus_txt.Text.Trim() != string.Empty && Kogus_txt.Text.Trim() != string.Empty && Hind_txt.Text.Trim() != string.Empty)
            {
                try
                {
                    using (var conn = GetConnection())
                    {
                        conn.Open();
                        cmd = new SqlCommand("UPDATE Toode SET Nimetus = @toode, Kogus = @kogus, Hind = @hind, pilt = @pilt WHERE Id = @id", conn);
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@toode", Nimetus_txt.Text);
                        cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                        cmd.Parameters.AddWithValue("@hind", Hind_txt.Text);
                        cmd.Parameters.AddWithValue("@pilt", Nimetus_txt.Text);
                        cmd.ExecuteNonQuery();
                    }

                    NaitaAndmed();
                    Eemaldamine();
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
            else
            {
                MessageBox.Show("Palun täida kõik andmed!");
            }
        }

        // Meetod pildi kuvamiseks eraldi aknas
        Form popupForm;

        private void Loopilt(Image image, int r)
        {
            popupForm = new Form();
            popupForm.FormBorderStyle = FormBorderStyle.None;
            popupForm.StartPosition = FormStartPosition.Manual;
            popupForm.Size = image.Size;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            popupForm.Controls.Add(pictureBox);

            Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(4, r, true);
            Point popupLocation = dataGridView1.PointToScreen(cellRectangle.Location);

            popupForm.Location = new Point(popupLocation.X + cellRectangle.Width, popupLocation.Y);
            popupForm.Show();
        }

        // Meetod pildi kuvamiseks hiireklõpsu kaudu
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4) // Eeldame, et pilt asub 4. veerus
            {
                byte[] imageData = dataGridView1.Rows[e.RowIndex].Cells["toodepilt"].Value as byte[]; // Kontrollime, kas see on õige veerg

                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        Loopilt(image, e.RowIndex);
                    }
                }
                else
                {
                    MessageBox.Show("Pilt ei ole saadaval.");
                }
            }
        }
    }
}
