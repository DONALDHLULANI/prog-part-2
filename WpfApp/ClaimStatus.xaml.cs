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

    public partial class ClaimStatus : Window
    {
        public ClaimStatus()
        {
            InitializeComponent();
        }

        // Method to search and load claim details by Claim ID
        private void SearchClaimButton_Click(object sender, RoutedEventArgs e)
        {
            string claimId = ClaimIdTextBox.Text;

            if (string.IsNullOrWhiteSpace(claimId))
            {
                MessageBox.Show("Please enter a valid Claim ID.");
                return;
            }

            Claim claim = ClaimData.GetClaimById(claimId);

            if (claim == null)
            {
                MessageBox.Show($"No claim found with ID: {claimId}");
                return;
            }

            LoadClaimDetails(claim);
        }

        // Method to load claim details and display the status history
        private void LoadClaimDetails(Claim claim)
        {
            List<string> claimHistory = new List<string>
            {
                $"Claim submitted by {claim.LecturerName}",
                "Claim reviewed by Manager"
            };

            if (claim.Status == "Pending")
            {
                claimHistory.Add("Coordinator is reviewing the claim");
                UpdateProgressBar(50);
            }
            else if (claim.Status == "Approved")
            {
                claimHistory.Add("Coordinator approved the claim");
                claimHistory.Add("Manager approved the claim");
                UpdateProgressBar(100);
            }
            else if (claim.Status == "Rejected")
            {
                claimHistory.Add("Coordinator rejected the claim");
                UpdateProgressBar(0);
            }

            ClaimHistoryListView.ItemsSource = claimHistory;

            ClaimStatusLabel.Text = $"Claim status: {claim.Status}";

        }

        // Method to update the progress bar based on claim status
        private void UpdateProgressBar(int progress)
        {
            ClaimProgressBar.Value = progress;
            ProgressLabel.Text = $"{progress}% Completed";
        }

        // Close button event handler
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}