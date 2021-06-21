using System.ComponentModel.DataAnnotations;

namespace TFCLPortal.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}