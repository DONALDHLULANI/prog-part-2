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
    public class VerifyClaimsTests
    {
        [TestMethod]
        public void ApproveClaim_ShouldSetStatusToApproved()
        {
            // Arrange
            var claim = new Claim { ClaimID = "C005", Status = "Pending" };
            ClaimData.AddClaim(claim);
            var verifyClaims = new VerifyClaims();

            // Act
            verifyClaims.ApproveClaim("C005");

            // Assert
            var claims = ClaimData.GetClaims();
            Assert.AreEqual("Approved", claims[0].Status);
        }

        [TestMethod]
        public void RejectClaim_ShouldSetStatusToRejected()
        {
            // Arrange
            var claim = new Claim { ClaimID = "C006", Status = "Pending" };
            ClaimData.AddClaim(claim);
            var verifyClaims = new VerifyClaims();

            // Act
            verifyClaims.RejectClaim("C006");

            // Assert
            var claims = ClaimData.GetClaims();
            Assert.AreEqual("Rejected", claims[0].Status);
        }

        [TestMethod]
        public void ApproveClaim_ShouldShowErrorMessageForInvalidClaim()
        {
            // Arrange
            var verifyClaims = new VerifyClaims();

            // Act
            string message = verifyClaims.ApproveClaim("INVALID_ID");

            // Assert
            Assert.AreEqual("Claim not found.", message);
        }
    }
}