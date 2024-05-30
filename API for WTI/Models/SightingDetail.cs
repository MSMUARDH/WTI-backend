namespace API_for_WTI.Models
{
    public class SightingDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string AirlineCode { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; } 
        public bool Active { get; set; } = true;
        public bool Delete { get; set; } = false;
        public int CreatedUserId { get; set; }
        public int ModifiedUserId { get; set; }
        public string PhotoPath { get; set; }
    }
}
