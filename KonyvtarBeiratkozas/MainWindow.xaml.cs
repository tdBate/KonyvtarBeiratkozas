using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace KonyvtarBeiratkozas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] mufajok = { "regény", "scifi", "fantasy", "ismeretterjesztő", "mese"};
        List<Olvaso> olvasok = new List<Olvaso>();
        public MainWindow()
        {
            InitializeComponent();
            cmbMufaj.ItemsSource = mufajok;
            

            string[] adatok = File.ReadAllText("olvasok.txt").Split("\n");
            foreach (var item in adatok)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    string[] mezok = item.Split(";");
                    string nev = mezok[0];
                    int kor = int.Parse(mezok[1]);
                    string mufaj = mezok[2];
                    List<string> ertesitesek = mezok[3].Split(",").ToList();
                    string tagsag = mezok[4];
                    Olvaso o1 = new Olvaso(nev, kor, mufaj, ertesitesek, tagsag);
                    olvasok.Add(o1);
                }
            }

            nevKiiras();


        }

        private void btnKuldes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nev = tbNev.Text;
                int kor = int.Parse(tbKor.Text);
                string mufaj = cmbMufaj.Text;
                List<string> ertesitesek = new List<string>();
                string tagsag = "";

                if (cbHirlevel.IsChecked == true)
                {
                    ertesitesek.Add("Hírlevél");
                }
                if (cbSms.IsChecked == true)
                {
                    ertesitesek.Add("Sms");
                }

                if (rbNormal.IsChecked == true)
                {
                    tagsag = "Alap";
                }
                else if (rbDiak.IsChecked == true)
                {
                    tagsag = "Prémium";
                }
                else if (rbNyugdijas.IsChecked == true)
                {
                    tagsag = "Nyugdíjas";
                }

                Olvaso o1 = new Olvaso(nev, kor, mufaj, ertesitesek, tagsag);
                tbEredmeny.Text = "Sikeres regisztráció!";
                o1.KiirFajlba();
                olvasok.Add(o1);
            }
            catch {
                tbEredmeny.Text = "Hiba az adatok bevitele során!";
            }
            nevKiiras();
        }

        private void tbKor_TextChanged(object sender, TextChangedEventArgs e)
        {
            string szoveg = "";
            for (int i =0; i<tbKor.Text.Length;i++)
            {
                if (!char.IsAsciiLetter(tbKor.Text[i]))
                {
                    szoveg += tbKor.Text[i];
                }
            }
            tbKor.Text = szoveg;
        }

        private void nevKiiras()
        {
            lbTagok.Items.Clear();
            foreach (var item in olvasok)
            {
                lbTagok.Items.Add(item.Nev);
            }
        }
    
    }
}