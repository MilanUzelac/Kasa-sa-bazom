using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVP2project
{
    class Racun
    {
        private int id_racun;
        private int cena;
        private DateTime datum;
        private DateTime vreme;

        public Racun()
        {
        }


        public Racun(int id_racun, int cena, DateTime datum, DateTime vreme)
        {
            this.Id_racun = id_racun;
            this.cena = cena;
            this.datum = datum;
            this.vreme = vreme;
        }

        public int Id_racun { get => id_racun; set => id_racun = value; }
        public int Cena { get => cena; set => cena = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
      
    }
}
