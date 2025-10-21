using System.Xml.Linq;

namespace WebApiNTT.Models
{
    public class ApiResponse
    {
        public List<Result>? Results { get; set; }
    }

    public class Result
    {
        public string? Gender { get; set; }
        public Name? Name { get; set; }
        public Location? Location { get; set; }
        public string? Email { get; set; }
        public Dob? Dob { get; set; }
        public Picture? Picture { get; set; }
    }
    public class Name
    {
        public string? First { get; set; }
        public string? Last { get; set; }
    }

    public class Location
    {
        public string? Country { get; set; }
    }

    public class Dob
    {
        public DateTime Date { get; set; }
    }

    public class Picture
    {
        public string? Large { get; set; }
    }
}
