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

namespace AC2_CodeFirst_IBelmonte_PBesalú
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DAO.IDAO dao = DAO.DAOFactory.GetDAO(new Entities.DbContextIBPB());
        public MainWindow()
        {
            InitializeComponent();
            dao.Import();
        }

        private void queryButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}