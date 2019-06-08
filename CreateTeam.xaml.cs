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
        public CreateTeam()
        {
            InitializeComponent();
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

                foreach (IDataConnection db in GlobalConfig.Connection)
                {
                    db.CreatePerson(p);
                }

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
    }
}
