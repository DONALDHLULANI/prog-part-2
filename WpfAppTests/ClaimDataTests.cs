using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Tests
{
    [TestClass]
    public class ClaimDataTests
    {
        [TestMethod]
        public void AddClaim_ShouldAddClaimToList()
        {
            // Arrange
            var claim = new Claim { ClaimID = "C001", LecturerName = "John Doe", TotalHours = 10, TotalAmount = 100, Status = "Pending" };
            ClaimData.AddClaim(claim);

            // Act
            List<Claim> claims = ClaimData.GetClaims();

            // Assert
            Assert.AreEqual(1, claims.Count);
            Assert.AreEqual("C001", claims[0].ClaimID);
        }

        [TestMethod]
        public void GetClaims_ShouldReturnEmptyListInitially()
        {
            // Act
            List<Claim> claims = ClaimData.GetClaims();

            // Assert
            Assert.AreEqual(0, claims.Count);
        }
    }
}