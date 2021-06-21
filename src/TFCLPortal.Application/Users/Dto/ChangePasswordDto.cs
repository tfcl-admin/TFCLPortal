using System.ComponentModel.DataAnnotations;

namespace TFCLPortal.Users.Dto
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }


    public class ChangeUserPasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public int UserId { get; set; }
    }


}
