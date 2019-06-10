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
        List<TournamentModel> tournaments;
        public MainWindow()
        {
            InitializeComponent();
            GlobalConfig.InitializeConnections(DatabaseType.TextFile);
            tournaments = GlobalConfig.Connection[0].GetTournament_All();
            WireUpLists();
        }
        
        private void WireUpLists()
        {
            Cbx_loadTournamentDropdown.ItemsSource = tournaments;
            Cbx_loadTournamentDropdown.DisplayMemberPath = "TournamentName";
        }

        private void Btn_Create_Tournament(object sender, RoutedEventArgs e)
        {
            CreateTournament createTournament = new CreateTournament();
            createTournament.Show();
            
        }

        private void Cbx_loadTournamentDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_loadTournament_Click(object sender, RoutedEventArgs e)
        {
            TournamentModel tm =(TournamentModel)Cbx_loadTournamentDropdown.SelectedItem;

            GameTracker gt = new GameTracker(tm);

            gt.Show();
        }
    }
}
