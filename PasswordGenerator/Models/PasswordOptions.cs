namespace PasswordGenerator.Models
{
    public class PasswordOptions
    {
        public int Length { get; set; } = 8;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSpecialCharacters { get; set; } = false;
    }
}
