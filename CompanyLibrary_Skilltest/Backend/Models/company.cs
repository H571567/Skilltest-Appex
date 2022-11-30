using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class company
    {
        public int Id { get; set; }
        public string OrgNr { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        [Required]
        public int UserId { get; set; }
        public AppUser appUser { get; set; }
    }
}
