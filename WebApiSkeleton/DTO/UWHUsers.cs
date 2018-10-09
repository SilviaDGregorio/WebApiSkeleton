using System.ComponentModel.DataAnnotations;

namespace WebApiSkeleton.DTO
{
    public class UWHUsers
    {

        [Required(ErrorMessage = "Missing Number")]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Invalid length for name", MinimumLength = 1)]
        [Required(ErrorMessage = "Missing name")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Invalid length for group", MinimumLength = 1)]
        [Required(ErrorMessage = "Missing group")]
        public string Group {get; set;}

        [StringLength(10, ErrorMessage = "Invalid length for position", MinimumLength = 1)]
        [Required(ErrorMessage = "Missing position")]
        public string Position {get; set;}
    }
}
