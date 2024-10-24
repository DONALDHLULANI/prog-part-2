using CMCS;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CMCSPrototype
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Children.Clear();
            MainContent.Children.Add(new TextBlock
            {
                Text = "Welcome to the Contract Monthly Claim System",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            var submitClaimWindow = new SubmitClaim();
            submitClaimWindow.Show();
        }

        private void VerifyClaims_Click(object sender, RoutedEventArgs e)
        {
            var verifyClaimsWindow = new VerifyClaims();
            verifyClaimsWindow.Show();
        }

        private void UploadDocuments_Click(object sender, RoutedEventArgs e)
        {
            var uploadDocumentsWindow = new UploadDocuments();
            uploadDocumentsWindow.Show();
        }

        private void ClaimStatus_Click(object sender, RoutedEventArgs e)
        {
            var claimStatusWindow = new ClaimStatus();
            claimStatusWindow.Show();
        }
    }
}