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
using System.Windows.Shapes;

namespace TournamentOrganiserACS
{
    /// <summary>
    /// Interaction logic for CreateTournament.xaml
    /// </summary>
    public partial class CreateTournament : Window
    {
        public CreateTournament()
        {
            InitializeComponent();
        }

        private void Btn_Create_Prize(object sender, RoutedEventArgs e)
        {
            CreatePrize createPrize = new CreatePrize();
            createPrize.Show();
            this.Close();
        }

        private void Btn_Create_Team(object sender, RoutedEventArgs e)
        {
            CreateTeam createTeam = new CreateTeam();
            createTeam.Show();
            this.Close();
        }
    }
}
