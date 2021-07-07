using ManagementHighStudySystem.Models;
using System.Collections.Generic;

namespace ManagementHighStudySystem.ViewModel
{
    public class UserViewModel
    {
        public ApplicationUser user { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<Path> Paths { get; set; }
        public int pathid { get; set; }
        public string id { set; get; }
        public IEnumerable<Status> Status { get; set; }
        public string StatusValue { get; set; }
    }
}