using System;
using System.Collections.Generic;

namespace Domain
{
    public class Package
    {
        public Guid PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Review { get; set; }
        public ICollection<Tour> Tour { get; set; }
    }
}