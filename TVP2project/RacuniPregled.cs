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
    public partial class RacuniPregled : Form
    {
        Baza baza;
        List<Artikal> lista;
        List<Racun> racuni;
        BindingList<Artikal> artikliRacun = new BindingList<Artikal>();
        List<Racun> racuniRange;

        private delegate void promeniLabelu();
        public RacuniPregled()
        {
            InitializeComponent();
            baza = new Baza();
            lista = new List<Artikal>();
            racuni = new List<Racun>();
           
            comboBox1.Items.Add("prva smena");
            comboBox1.Items.Add("druga smena");
           
     
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
                Invalidate();
                Thread.Sleep(1000);
                
            }
        }


        private void RacuniPregled_Load(object sender, EventArgs e)
        {
            baza = new Baza();
            lista = new List<Artikal>();
            racuni = new List<Racun>();
            racuniRange = new List<Racun>();
            new Task(PostaviVreme).Start();
            dateTimePicker3.Format = DateTimePickerFormat.Time;
            dateTimePicker3.ShowUpDown = true;

            dateTimePicker4.Format = DateTimePickerFormat.Time;
            dateTimePicker4.ShowUpDown = true;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                    r.Datum = DateTime.Parse(DateTime.Parse(reader["datum"].ToString()).ToShortDateString());
                    r.Vreme = DateTime.Parse(DateTime.Parse(reader["vreme"].ToString()).ToShortTimeString());
                    racuni.Add(r);
                }

                //AKO JE IZABRANO FILTRIRANJE PO DATUMU
                if (radioButton1.Checked) {
                    for (int i = 0; i < racuni.Count; i++)
                    {
                        if ((dateTimePicker1.Value.Date.Add(dateTimePicker3.Value.TimeOfDay) < racuni[i].Datum.Date.Add(racuni[i].Vreme.TimeOfDay) && (dateTimePicker2.Value.Date.Add(dateTimePicker4.Value.TimeOfDay) > racuni[i].Datum.Date.Add(racuni[i].Vreme.TimeOfDay))))
                        {
                            racuniRange.Add(racuni[i]);
                        }
                    }
                }

                

                //AKO JE IZABRANO FILTRIRANJE PO SMENAMA
                if (radioButton2.Checked) {
                    if (comboBox1.Text == "prva smena")
                    {
                        for (int i = 0; i < racuni.Count; i++)
                        {
                            if ((dateTimePicker5.Value.Date.Add(new TimeSpan(6, 00, 00)) < racuni[i].Vreme) && (dateTimePicker6.Value.Date.Add(new TimeSpan(15, 00, 00)) > racuni[i].Vreme))
                            {
                                racuniRange.Add(racuni[i]);
                            }
                        }
                    }
                   

                    if (comboBox1.Text == "druga smena")
                    {
                        for (int i = 0; i < racuni.Count; i++)
                        {
                            if ((dateTimePicker5.Value.Date.Add(new TimeSpan(15, 00, 00)) < racuni[i].Vreme) && (dateTimePicker6.Value.Date.Add(new TimeSpan(23, 00, 00)) > racuni[i].Vreme))
                            {
                                racuniRange.Add(racuni[i]);
                            }
                        }
                    }

                    
                }
               
                dataGridView1.DataSource = racuniRange;
                dataGridView1.Columns["vreme"].DefaultCellStyle.Format = "HH:mm";
                dataGridView1.Refresh();
                this.RacuniPregled_Load(this, e);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
        }

    }
}
