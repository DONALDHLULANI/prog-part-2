using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMCS.Tests
{
    [TestClass]
    public class ClaimStatusTests
    {
        [TestMethod]
        public void SearchClaim_ShouldReturnCorrectHistoryForValidClaim()
        {
            // Arrange
            var claim = new Claim { ClaimID = "C002", LecturerName = "Jane Smith", Status = "Pending" };
            ClaimData.AddClaim(claim);
            var claimStatus = new ClaimStatus();

            // Act
            var claimFound = claimStatus.SearchClaim("C002");

            // Assert
            Assert.IsTrue(claimFound);
            Assert.AreEqual("Jane Smith", claimStatus.GetLecturerName());
        }

        [TestMethod]
        public void SearchClaim_ShouldReturnFalseForInvalidClaim()
        {
            // Arrange
            var claimStatus = new ClaimStatus();

            // Act
            var claimFound = claimStatus.SearchClaim("INVALID_ID");

            // Assert
            Assert.IsFalse(claimFound);
        }

        [TestMethod]
        public void CalculateProgress_ShouldReturn50PercentForPendingClaim()
        {
            // Arrange
            var claim = new Claim { ClaimID = "C003", Status = "Pending" };
            ClaimData.AddClaim(claim);
            var claimStatus = new ClaimStatus();

            // Act
            claimStatus.SearchClaim("C003");
            int progress = claimStatus.CalculateProgress();

            // Assert
            Assert.AreEqual(50, progress);
        }

        [TestMethod]
        public void CalculateProgress_ShouldReturn100PercentForApprovedClaim()
        {
            // Arrange
            var claim = new Claim { ClaimID = "C004", Status = "Approved" };
            ClaimData.AddClaim(claim);
            var claimStatus = new ClaimStatus();

            // Act
            claimStatus.SearchClaim("C004");
            int progress = claimStatus.CalculateProgress();

            // Assert
            Assert.AreEqual(100, progress);
        }
    }
}