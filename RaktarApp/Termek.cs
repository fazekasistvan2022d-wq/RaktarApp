using System;
using System.Collections.Generic;
using System.Text;

namespace RaktarApp
{
    internal class Termek
    {
        public string Cikkszam { get; set; }
        protected int alapar;
        public int Alapar
        {
            get{ return alapar; }
            set
            {
                if(value <= 0)
                {
                    value = 1_000;
                }
                else
                {
                    alapar = value;
                }
            }
        }
        private static int osszesTermekSzama = 0;
        public static int OsszesTermekSzama
        {
            get { return osszesTermekSzama; }
        }

        public Termek(string cikkszam, int alapar)
        {
            Cikkszam = cikkszam;
            this.alapar = alapar;
            osszesTermekSzama++;
        }

        public virtual int ErtekSzamitas(int darabszam)
        {
            return alapar * darabszam;
        }
        public override string ToString()
        {
            return $"Cikkszám: {Cikkszam}, Alapár: {alapar}";
        }
    }
}
