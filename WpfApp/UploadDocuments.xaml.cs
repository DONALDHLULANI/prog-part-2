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
    public partial class UploadDocuments : Window
    {
        // List to store uploaded documents
        private List<string> uploadedDocuments;

        public UploadDocuments()
        {
            InitializeComponent();
            uploadedDocuments = new List<string>();
        }

        // Browse for a document file
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Word documents (*.doc;*.docx)|*.doc;*.docx|Excel files (*.xls;*.xlsx)|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        // Upload the selected document
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;
            string claimId = ClaimIdTextBox.Text;

            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(claimId))
            {
                MessageBox.Show("Please provide both a Claim ID and a file to upload.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            uploadedDocuments.Add(filePath);
            UploadedDocumentsListView.Items.Add(filePath);

            FilePathTextBox.Text = string.Empty;

            MessageBox.Show($"Document uploaded for Claim ID: {claimId}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Close the window
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}