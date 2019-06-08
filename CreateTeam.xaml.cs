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
    /// Interaction logic for CreateTeam.xaml
    /// </summary>
    public partial class CreateTeam : Window
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection[0].GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeam()
        {
            InitializeComponent();

            WireUpLists();
        }

       
        private void WireUpLists()
        {
            Cbx_selectTeamMemberDropDown.ItemsSource = null;

            Cbx_selectTeamMemberDropDown.ItemsSource = availableTeamMembers;
            Cbx_selectTeamMemberDropDown.DisplayMemberPath = "FullName";

            Lbx_teamMembersListBox.ItemsSource = null;

            Lbx_teamMembersListBox.ItemsSource = selectedTeamMembers;
            Lbx_teamMembersListBox.DisplayMemberPath = "FullName";
        }

        private void Btn_createMember_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                PersonModel p = new PersonModel();
                p.FirstName = Tbx_firstNameValue.Text;
                p.LastName = Tbx_lastNameValue.Text;
                p.EmailAddress = Tbx_emailValue.Text;
                p.MobileNumber = Tbx_mobileNumberValue.Text;

                p = GlobalConfig.Connection[0].CreatePerson(p);
                selectedTeamMembers.Add(p);

                WireUpLists();



                Tbx_firstNameValue.Text = "";
                Tbx_lastNameValue.Text = "";
                Tbx_emailValue.Text = "";
                Tbx_mobileNumberValue.Text = "";


            }
            else
            {
                MessageBox.Show("You need to fill in all the fields");
            }
        }
        private bool validate()
        {
            if(Tbx_firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if(Tbx_lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (Tbx_emailValue.Text.Length == 0)
            {
                return false;
            }

            if (Tbx_mobileNumberValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void Btn_addMember_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)Cbx_selectTeamMemberDropDown.SelectedItem;
            if(p!= null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void Btn_deleteSelectedMember_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)Lbx_teamMembersListBox.SelectedItem;

            if(p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void Btn_createTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamModel t = new TeamModel();

            t.TeamName = Tbx_teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            t = GlobalConfig.Connection[0].CreateTeam(t);

            //TODO: IF not closing after creation , reset the window.
        }
    }
}
