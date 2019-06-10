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
    public partial class CreateTournament : Window, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection[0].GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournament()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            Cbx_selectTeamDropDown.ItemsSource = null;

            Cbx_selectTeamDropDown.ItemsSource = availableTeams;
            Cbx_selectTeamDropDown.DisplayMemberPath = "TeamName";

            Lbx_tournamentPlayers.ItemsSource = null;

            Lbx_tournamentPlayers.ItemsSource = selectedTeams;
            Lbx_tournamentPlayers.DisplayMemberPath = "TeamName";

            Lbx_prizes.ItemsSource = null;
            Lbx_prizes.ItemsSource = selectedPrizes;
            Lbx_prizes.DisplayMemberPath = "PlaceName";
        }

        private void Btn_Create_Prize(object sender, RoutedEventArgs e)
        {
            CreatePrize createPrizeWindow = new CreatePrize(this);
            createPrizeWindow.Show();
            
        }

        private void Btn_Create_Team(object sender, RoutedEventArgs e)
        {
            CreateTeam createTeamWindow = new CreateTeam(this);
            createTeamWindow.Show();
            
        }

        private void Cbx_selectTeamDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_addTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamModel t = (TeamModel)Cbx_selectTeamDropDown.SelectedItem;

            if(t!= null)
            {
                availableTeams.Remove(t);
                selectedTeams.Add(t);

                WireUpLists();
            }
        }

        public void PrizeComplete(PrizeModel model)
        {
            selectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void Btn_deleteSelectedTeams_Click(object sender, RoutedEventArgs e)
        {
            TeamModel t = (TeamModel)Lbx_tournamentPlayers.SelectedItem;

            if(t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);
                WireUpLists();
            }
        }

        private void Btn_deleteSelectedPrizes_Click(object sender, RoutedEventArgs e)
        {
            PrizeModel p = (PrizeModel)Lbx_prizes.SelectedItem;

            if(p != null)
            {
                selectedPrizes.Remove(p);
                WireUpLists();
            }
        }

        private void Btn_createTournament_Click(object sender, RoutedEventArgs e)
        {
            decimal fee = 0;
            bool feeAcceptable = decimal.TryParse(Tbx_entryFeeValue.Text, out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("Please enter a valid Entry Fee");
                return;
            }

            TournamentModel tm = new TournamentModel();

            tm.TournamentName = Tbx_tournamentNameValue.Text;
            tm.EntryFee = fee;

            tm.Prizes = selectedPrizes;
            tm.EnteredTeams = selectedTeams;

            TournamentLogic.CreateRounds(tm);

            GlobalConfig.Connection[0].CreateTournament(tm);
        }
    }
}
