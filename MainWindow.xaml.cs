using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TournamentOrganiserACS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GlobalConfig.InitializeConnections(DatabaseType.TextFile);
        }
        

        private void Btn_Create_Tournament(object sender, RoutedEventArgs e)
        {
            CreateTournament createTournament = new CreateTournament();
            createTournament.Show();
            this.Close();
        }
    }
}
