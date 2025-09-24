using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KonyvtarBeiratkozas
{
    class Olvaso
    {
        private string nev;
        private int kor;
        private string mufaj;
        List<string> ertesitesek = new List<string>();
        private string tagsagiTipus;

        public Olvaso(string nev, int kor, string mufaj, List<string> ertesitesek, string tagsagiTipus)
        {
            this.nev = nev;
            this.kor = kor;
            this.mufaj = mufaj;
            this.ertesitesek = ertesitesek;
            this.tagsagiTipus = tagsagiTipus;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Kor { get => kor; set => kor = value; }
        public string Mufaj { get => mufaj; set => mufaj = value; }
        public List<string> Ertesitesek { get => ertesitesek; set => ertesitesek = value; }
        public string TagsagiTipus { get => tagsagiTipus; set => tagsagiTipus = value; }

        public void KiirFajlba()
        { 
            string text = nev + ";" + kor + ";" + mufaj + ";" + string.Join(",", ertesitesek) + ";" + tagsagiTipus+" \n";
            File.AppendAllText("olvasok.txt", text);
        }
    }
}
