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
    /// Interaction logic for CreatePrize.xaml
    /// </summary>
    public partial class CreatePrize : Window
    {
        public CreatePrize()
        {
            InitializeComponent();
        }

        private void Btn_createPrize_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                PrizeModel model = new PrizeModel(Tbx_placeNameValue.Text, Tbx_placeNumberValue.Text, Tbx_prizeAmountValue.Text);
                
                foreach(IDataConnection db in GlobalConfig.Connection)
                {
                    db.CreatePrize(model);
                }

                Tbx_placeNameValue.Text = "";
                Tbx_placeNumberValue.Text = "";
                Tbx_prizeAmountValue.Text = "0"; 
            }
            else
            {
                MessageBox.Show("Invalid Information, please try again");
            }
        }

        private bool Validate()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(Tbx_placeNumberValue.Text, out placeNumber);

             if (!placeNumberValidNumber)
            {
                output = false;
            }

            if(placeNumber < 1)
            {
                output = false;
            }

            if(Tbx_placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            bool prizeAmountValid = decimal.TryParse(Tbx_prizeAmountValue.Text, out prizeAmount);

            if (!prizeAmountValid)
            {
                output = false;
            }

            if(prizeAmount <= 0)
            {
                output = false;
            }

            return output;
        }
    }
}
