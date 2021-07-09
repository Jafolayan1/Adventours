using System;

namespace Domain
{
    public class Tour
    {
        public Guid TourId { get; set; }
        public string TourCenterName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int? Rating { get; set; }
        public string Category { get; set; }
        public Guid PackageId { get; set; }
        public Package Package { get; set; }
    }
}