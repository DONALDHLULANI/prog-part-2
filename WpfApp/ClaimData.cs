using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS
{
    public static class ClaimData
    {
        private static List<Claim> claims = new List<Claim>();

        // Method to add a new claim
        public static void AddClaim(Claim claim)
        {
            claims.Add(claim);
        }

        // Method to retrieve all claims
        public static List<Claim> GetClaims()
        {
            return claims;
        }

        // Method to retrieve a claim by ClaimID
        public static Claim GetClaimById(string claimId)
        {
            return claims.FirstOrDefault(c => c.ClaimID == claimId);
        }
    }

    // Model class to represent a claim
    public class Claim
    {
        public string ClaimID { get; set; }
        public string LecturerName { get; set; }
        public double TotalHours { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
    }
}