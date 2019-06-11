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

            WireUpRoundsLists();

            WireUpMatchupLists();

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

        private void WireUpRoundsLists()
        {
            if(Cbx_roundDropDown.ItemsSource == null)
            {
                Cbx_roundDropDown.ItemsSource = rounds;
               
            }

           
        }

        private void WireUpMatchupLists()
        {
            Lbx_matchup.ItemsSource = null;
            Lbx_matchup.ItemsSource = selectedMatchups;
            Lbx_matchup.DisplayMemberPath = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds.Clear();

            rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if(matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);

                }
            }

            WireUpRoundsLists();
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
            WireUpMatchupLists();


        }

        private void LoadMatchupSelectionChanged()
        {
            MatchupModel m = (MatchupModel)Lbx_matchup.SelectedItem;
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        Lbl_teamOnename.Content = m.Entries[0].TeamCompeting.TeamName;
                        Tbx_teamOneScore.Text = m.Entries[0].Score.ToString();

                        Lbl_teamTwoName.Content = "Bye";
                        Tbx_teamTwoScore.Text = "0";
                    }
                    else
                    {
                        Lbl_teamOnename.Content = "Not yet set";
                        Tbx_teamOneScore.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        Lbl_teamTwoName.Content = m.Entries[1].TeamCompeting.TeamName;
                        Tbx_teamTwoScore.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        Lbl_teamTwoName.Content = "Not yet set";
                        Tbx_teamTwoScore.Text = "";
                    }
                }
            }
        }

        private void Lbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMatchupSelectionChanged();
        }
    }
}
