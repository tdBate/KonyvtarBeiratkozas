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

namespace KonyvtarBeiratkozas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] mufajok = { "regény", "scifi", "fantasy", "ismeretterjesztő", "mese"};
        public MainWindow()
        {
            InitializeComponent();
            cmbMufaj.ItemsSource = mufajok;
        }
    }
}