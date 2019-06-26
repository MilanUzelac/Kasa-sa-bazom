using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVP2project
{
    public partial class DodavanjeForm : Form
    {

        Baza baza;
        List<Artikal> lista;
        private delegate void promeniLabelu();
        public DodavanjeForm()
        {

            InitializeComponent();
            baza = new Baza();
            lista = new List<Artikal>();
           
        }



        //DODAVANJE NOVOG ARTIKLA
        private void button1_Click(object sender, EventArgs e)
        {
            this.DodavanjeForm_Load(this, e);

            //PROVERE
            string pattern = @"^[0-9]\d*$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, pattern))
            {
                MessageBox.Show("Morate uneti cenu a ne slovo...");
                textBox2.Text = "";
            }
            
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, pattern))
            {
                MessageBox.Show("Morate uneti brojeve za procenat...");
                textBox3.Text = "";
            }

            //AKO JE IZABRAN RADIOBUTTON ZA NAMIRNICE, DODAJE ARTIKAL U GRUPU 1
            if (radioButton1.Checked)
            {
                try
                {
                    baza.OtvoriKonekciju();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = @"INSERT INTO 
                Artikal(id_artikla,naziv,cena,popust,id_grupa)VALUES(@id_artikla,@naziv,@cena,@popust,@id_grupa)";
                    cmd.Parameters.AddWithValue("id_artikla", id);
                    cmd.Parameters.AddWithValue("naziv", textBox1.Text);
                    cmd.Parameters.AddWithValue("cena", Convert.ToInt32(textBox2.Text));
                    cmd.Parameters.AddWithValue("popust", Convert.ToInt32(textBox3.Text));
                    cmd.Parameters.AddWithValue("id_grupa", 1);
                    int rezultat = cmd.ExecuteNonQuery();
                    if (rezultat > 0)
                        MessageBox.Show("Uspesno dodat artikal u bazu!");
                    else
                        MessageBox.Show("Dodavanje artikla nije uspelo!");
                }
                catch (Exception ex)
                {
                   
                }
                finally { baza.ZatvoriKonekciju(); }

            }


            //AKO JE IZABRAN RADIOBUTTON ZA VOCE I POVRCE, DODAJE ARTIKAL U GRUPU 2
                if (radioButton2.Checked)
                {
                    try
                    {
                        baza.OtvoriKonekciju();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baza.Conn;
                        cmd.CommandText = @"INSERT INTO 
                Artikal(id_artikla,naziv,cena,popust,id_grupa)VALUES(@id_artikla,@naziv,@cena,@popust,@id_grupa)";
                        cmd.Parameters.AddWithValue("id_artikla", id);
                        cmd.Parameters.AddWithValue("naziv", textBox1.Text);
                        cmd.Parameters.AddWithValue("cena", Convert.ToInt32(textBox2.Text));
                        cmd.Parameters.AddWithValue("popust", Convert.ToInt32(textBox3.Text));
                        cmd.Parameters.AddWithValue("id_grupa", 2);
                        int rezultat = cmd.ExecuteNonQuery();
                        if (rezultat > 0)
                            MessageBox.Show("Uspesno dodat artikal u bazu!");
                        else
                            MessageBox.Show("Dodavanje artikla nije uspelo!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { baza.ZatvoriKonekciju(); }

                }




            //AKO JE IZABRAN RADIOBUTTON ZA PIĆE, DODAJE ARTIKAL U GRUPU 3
                if (radioButton3.Checked)
                {
                    MessageBox.Show("Pice rb3");
                    try
                    {
                        baza.OtvoriKonekciju();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baza.Conn;
                        cmd.CommandText = @"INSERT INTO 
                Artikal(id_artikla,naziv,cena,popust,id_grupa)VALUES(@id_artikla,@naziv,@cena,@popust,@id_grupa)";
                        cmd.Parameters.AddWithValue("id_artikla", id);
                        cmd.Parameters.AddWithValue("naziv", textBox1.Text);
                        cmd.Parameters.AddWithValue("cena", Convert.ToInt32(textBox2.Text));
                        cmd.Parameters.AddWithValue("popust", Convert.ToInt32(textBox3.Text));
                        cmd.Parameters.AddWithValue("id_grupa", 3);
                        int rezultat = cmd.ExecuteNonQuery();
                        if (rezultat > 0)
                            MessageBox.Show("Uspesno dodat artikal u bazu!");
                        else
                            MessageBox.Show("Dodavanje artikla nije uspelo!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { baza.ZatvoriKonekciju(); }

                }





            //AKO JE IZABRAN RADIOBUTTON ZA HEMIJU, DODAJE ARTIKAL U GRUPU 4
            if (radioButton4.Checked)
                {
                    try
                    {
                        baza.OtvoriKonekciju();
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = baza.Conn;
                        cmd.CommandText = @"INSERT INTO 
                Artikal(id_artikla,naziv,cena,popust,id_grupa)VALUES(@id_artikla,@naziv,@cena,@popust,@id_grupa)";
                        cmd.Parameters.AddWithValue("id_artikla", id);
                        cmd.Parameters.AddWithValue("naziv", textBox1.Text);
                        cmd.Parameters.AddWithValue("cena", Convert.ToInt32(textBox2.Text));
                        cmd.Parameters.AddWithValue("popust", Convert.ToInt32(textBox3.Text));
                        cmd.Parameters.AddWithValue("id_grupa", 4);
                        int rezultat = cmd.ExecuteNonQuery();
                        if (rezultat > 0)
                            MessageBox.Show("Uspesno dodat artikal u bazu!");
                        else
                            MessageBox.Show("Dodavanje artikla nije uspelo!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { baza.ZatvoriKonekciju(); }

                }

           
        }


        //PRIKAZ VREMENA
        private void vreme()
        {
            label6.Text = DateTime.Now.ToString("dd.MM. HH:mm:ss");
            Invalidate();
        }

        private void PostaviVreme()
        {
            while (IsDisposed == false)
            {
                Invoke(new promeniLabelu(vreme));
                Thread.Sleep(1000);
            }
        }



        public static int id=-1;

        private void DodavanjeForm_Load(object sender, EventArgs e)
        {
            //pokrecemo vreme
            new Task(PostaviVreme).Start();
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Artikal";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artikal a = new Artikal();
                    a.Id_artikla = int.Parse(reader["id_artikla"].ToString());
                    a.Naziv = reader["naziv"].ToString();
                    a.Cena = int.Parse(reader["cena"].ToString());
                    a.Popust = int.Parse(reader["popust"].ToString());
                    lista.Add(a);
                    id = a.Id_artikla + 1;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
 
        }
    }
}
