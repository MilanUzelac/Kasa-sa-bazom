using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP2project
{
    public partial class Form1 : Form
    {

        Baza baza;
        List<Artikal> lista;
        List<Racun> racuni;
        BindingList<Artikal> artikliRacun = new BindingList<Artikal>();
        //delegat za vreme
        private delegate void promeniLabelu();
        

        public Form1()
        {
            InitializeComponent();
            baza = new Baza();
            lista = new List<Artikal>();
            racuni = new List<Racun>();
            new Task(PostaviVreme).Start();
        }

        
        //IZLISTAVANJE ARTIKALA IZ BAZE SA ID GRUPE 1
        private void button1_Click(object sender, EventArgs e)
        {
           
            try {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Artikal WHERE id_grupa=1";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artikal a = new Artikal();
                    a.Id_artikla = int.Parse(reader["id_artikla"].ToString());
                    a.Naziv = reader["naziv"].ToString();
                    a.Cena = int.Parse(reader["cena"].ToString());
                    a.Popust = int.Parse(reader["popust"].ToString());
                    lista.Add(a);
                }
                dataGridView1.DataSource = lista;
                dataGridView1.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
            this.Form1_Load(this,e);
            
        }


        //IZLISTAVANJE ARTIKALA IZ BAZE SA ID GRUPE 2
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Artikal WHERE id_grupa=2";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artikal a = new Artikal();
                    a.Id_artikla = int.Parse(reader["id_artikla"].ToString());
                    a.Naziv = reader["naziv"].ToString();
                    a.Cena = int.Parse(reader["cena"].ToString());
                    a.Popust = int.Parse(reader["popust"].ToString());
                    lista.Add(a);
                }
                dataGridView1.DataSource = lista;
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
            this.Form1_Load(this, e);
        }

        //IZLISTAVANJE ARTIKALA IZ BAZE SA ID GRUPE 3
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Artikal WHERE id_grupa=3";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artikal a = new Artikal();
                    a.Id_artikla = int.Parse(reader["id_artikla"].ToString());
                    a.Naziv = reader["naziv"].ToString();
                    a.Cena = int.Parse(reader["cena"].ToString());
                    a.Popust = int.Parse(reader["popust"].ToString());
                    lista.Add(a);
                }
                dataGridView1.DataSource = lista;
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
            this.Form1_Load(this, e);

        }


        //IZLISTAVANJE ARTIKALA IZ BAZE SA ID GRUPE 4
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Artikal WHERE id_grupa=4";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artikal a = new Artikal();
                    a.Id_artikla = int.Parse(reader["id_artikla"].ToString());
                    a.Naziv = reader["naziv"].ToString();
                    a.Cena = int.Parse(reader["cena"].ToString());
                    a.Popust = int.Parse(reader["popust"].ToString());
                    lista.Add(a);
                }
                dataGridView1.DataSource = lista;
                dataGridView1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
            this.Form1_Load(this, e);
        }


        //prikaz vremena
        private void vreme() {
            label9.Text = DateTime.Now.ToString("dd.MM. HH:mm:ss");
            Invalidate();
        }

        private void PostaviVreme() {
            while (IsDisposed == false) {
                Invoke(new promeniLabelu(vreme));
                Thread.Sleep(1000);
            }
        }



        public static int racunId = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            baza = new Baza();
            lista = new List<Artikal>();
            racuni = new List<Racun>();
            
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Racun";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Racun r = new Racun();
                    r.Id_racun = int.Parse(reader["id_racun"].ToString());
                    r.Cena = int.Parse(reader["cena"].ToString());
                    r.Datum = DateTime.Parse(DateTime.Parse(reader["datum"].ToString()).ToShortDateString()); ;
                    r.Vreme = DateTime.Parse(DateTime.Parse(reader["vreme"].ToString()).ToShortTimeString());
                    racuni.Add(r);
                    racunId = r.Id_racun + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }

        }


        //OTVARA SE FORMA ZA DODAVANJE ARTIKLA
        private void button5_Click(object sender, EventArgs e)
        {
            
            DodavanjeForm df = new DodavanjeForm();
            df.Show();
        }


        //UBACIVANJE ARTIKLA U RACUN
        int ukupnaCena = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;

            try
            {
                string pattern = @"^[1-9]\d*$";

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, pattern))
                {
                    MessageBox.Show("Morate uneti cele brojeve...");
                    textBox1.Text = "";
                }
                else
                {
                    Artikal a = new Artikal
                    {
                        Id_artikla = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString()),
                        Naziv = dataGridView1.Rows[rowindex].Cells[columnindex + 1].Value.ToString(),
                        Cena = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex + 2].Value.ToString()) * Convert.ToInt32(textBox1.Text),
                        Popust = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[columnindex + 3].Value.ToString())
                    };
                    artikliRacun.Add(a);
                    ukupnaCena += a.Cena;
                    textBox2.Text = ukupnaCena.ToString();

                    if (dataGridView2.DataSource != null)
                    {
                        dataGridView2.DataSource = null;
                    }

                    dataGridView2.DataSource = artikliRacun;
                    dataGridView2.Refresh();
                    textBox1.Text = "";

                    this.Form1_Load(this, e);

                }

            }
            catch (Exception ex) {
                
            }

        }


        //UKLANJANJE ARTIKLA SA RACUNA
        private void button6_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            int cena=Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells[columnindex + 2].Value.ToString());
            ukupnaCena -= cena;
            dataGridView2.Rows.RemoveAt(rowIndex);
            textBox2.Text = ukupnaCena.ToString();
        }


        private DateTime GetDate(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }


        //ZAVRSAVANJE RACUNA - DODAVANJE U BAZU
        private void button8_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;


            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "INSERT INTO Racun(id_racun,cena,datum,vreme)VALUES(@id_racun,@cena,@datum,@vreme)";

                cmd.Parameters.AddWithValue("id_racun", racunId);
                cmd.Parameters.AddWithValue("cena", Convert.ToInt32(textBox2.Text));
                cmd.Parameters.AddWithValue("datum", GetDate(DateTime.Now));
                cmd.Parameters.AddWithValue("vreme", GetDate(DateTime.Now));
                int rezultat = cmd.ExecuteNonQuery();
                if (rezultat > 0)
                    MessageBox.Show("Uspesno dodat racun u bazu!");
                else
                    MessageBox.Show("Dodavanje racuna nije uspelo");

                this.Form1_Load(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }

        }

        //PRIKAZ FORME ZA PREGLED RACUNA
        private void button9_Click(object sender, EventArgs e)
        {
            RacuniPregled rp = new RacuniPregled();
            rp.Show();
        }
    }
}
