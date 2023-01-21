using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Address
    {
        public string zipCode { get; set; }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(zipCode)) { return false; }
            if (Regex.Matches(zipCode.Replace("-", ""), @"[a-zA-Z]").Count > 0) return false;
            if (zipCode.Replace("-", "").Length != 8) return false;

            return true;
        }
    }
}
