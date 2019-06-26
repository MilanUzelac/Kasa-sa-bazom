using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP2project
{
    class Artikal
    {
        private int id_artikla;
        private string naziv;
        private int cena;
        private int popust;

        public Artikal(int id_artikla, string naziv, int cena, int popust)
        {
            this.id_artikla = id_artikla;
            this.naziv = naziv;
            this.cena = cena;
            this.popust = popust;
        }

        public Artikal() { }

        public int Id_artikla { get => id_artikla; set => id_artikla = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int Cena { get => cena; set => cena = value; }
        public int Popust { get => popust; set => popust = value; }
    }
}
