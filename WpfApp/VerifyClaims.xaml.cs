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

namespace CMCS
{
    public partial class VerifyClaims : Window
    {
        public VerifyClaims()
        {
            InitializeComponent();
            LoadClaimsData();
        }

        // Load claims data into the DataGrid
        private void LoadClaimsData()
        {
            List<Claim> claims = ClaimData.GetClaims();
            ClaimsDataGrid.ItemsSource = claims;
        }

        // Handle the 'Approve' button click
        private void ApproveClaim_Click(object sender, RoutedEventArgs e)
        {
            Claim selectedClaim = ClaimsDataGrid.SelectedItem as Claim;
            if (selectedClaim != null)
            {
                selectedClaim.Status = "Approved";
                ClaimsDataGrid.Items.Refresh();
                MessageBox.Show($"Claim {selectedClaim.ClaimID} approved.");
            }
            else
            {
                MessageBox.Show("Please select a claim to approve.");
            }
        }

        // Handle the 'Reject' button click
        private void RejectClaim_Click(object sender, RoutedEventArgs e)
        {
            Claim selectedClaim = ClaimsDataGrid.SelectedItem as Claim;
            if (selectedClaim != null)
            {
                selectedClaim.Status = "Rejected";
                ClaimsDataGrid.Items.Refresh();
                MessageBox.Show($"Claim {selectedClaim.ClaimID} rejected.");
            }
            else
            {
                MessageBox.Show("Please select a claim to reject.");
            }
        }

        // Handle the 'Close' button click
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
