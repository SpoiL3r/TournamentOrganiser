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
    /// Interaction logic for GameTracker.xaml
    /// </summary>
    public partial class GameTracker : Window
    {
        private TournamentModel tournament;
        List<int> rounds = new List<int>();
        List<MatchupModel> selectedMatchups = new List<MatchupModel>();

        public GameTracker(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            LoadTournamentData();

            LoadRounds();
        }

        private void LoadTournamentData()
        {
            if(tournament == null)
            {
                return;
            }
            Lbl_tournamentName.Content = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            if(Cbx_roundDropDown.ItemsSource == null)
            {
                Cbx_roundDropDown.ItemsSource = rounds;
            }

            Lbx_matchup.ItemsSource = null;
            Lbx_matchup.ItemsSource = selectedMatchups;
            Lbx_matchup.DisplayMemberPath = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds = new List<int>();

            rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if(matchups.First().MatchupRound > currentRound)
                {
                    selectedMatchups = matchups;

                }
            }

            WireUpLists();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMatchups();
        }

        private void LoadMatchups()
        {
            if(Cbx_roundDropDown.SelectedItem != null)
            {
                int round = (int)Cbx_roundDropDown.SelectedItem;

                foreach (List<MatchupModel> matchups in tournament.Rounds)
                {
                    if (matchups.First().MatchupRound == round)
                    {
                        selectedMatchups = matchups;

                    }
                }
            }

            WireUpLists();
        }
    }
}
