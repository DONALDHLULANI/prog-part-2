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
using Microsoft.Win32;


namespace CMCS
{
    public partial class SubmitClaim : Window
    {
        public SubmitClaim()
        {
            InitializeComponent();
        }

        private void BrowseDocument_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Document files (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx",
                Title = "Select a Document"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                DocumentPathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve form data
            string lecturerName = LecturerNameTextBox.Text;
            string claimId = ClaimIdTextBox.Text;
            string hoursWorkedText = HoursWorkedTextBox.Text;
            string hourlyRateText = HourlyRateTextBox.Text;
            string documentPath = DocumentPathTextBox.Text;

            // Input validation
            if (string.IsNullOrWhiteSpace(lecturerName) || string.IsNullOrWhiteSpace(claimId) ||
                string.IsNullOrWhiteSpace(hoursWorkedText) || string.IsNullOrWhiteSpace(hourlyRateText))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (!double.TryParse(hoursWorkedText, out double hoursWorked) || hoursWorked <= 0)
            {
                MessageBox.Show("Please enter a valid number for hours worked.");
                return;
            }

            if (!double.TryParse(hourlyRateText, out double hourlyRate) || hourlyRate <= 0)
            {
                MessageBox.Show("Please enter a valid hourly rate.");
                return;
            }

            Claim newClaim = new Claim
            {
                ClaimID = claimId,
                LecturerName = lecturerName,
                TotalHours = hoursWorked,
                TotalAmount = hoursWorked * hourlyRate,
                Status = "Pending"
            };

            // Save the claim
            ClaimData.AddClaim(newClaim);

            // Show success message
            MessageBox.Show("Claim submitted successfully!");

            // Clear form
            ClearForm();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the form without saving any data
            this.Close();
        }

        // Clears the form after submission
        private void ClearForm()
        {
            LecturerNameTextBox.Text = string.Empty;
            ClaimIdTextBox.Text = string.Empty;
            HoursWorkedTextBox.Text = string.Empty;
            HourlyRateTextBox.Text = string.Empty;
            DocumentPathTextBox.Text = string.Empty;
        }
    }
}