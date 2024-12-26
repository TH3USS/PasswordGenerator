using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Models;
using System;
using System.Text;

namespace PasswordGenerator.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            return View(new PasswordOptions());
        }

        [HttpPost]
        public IActionResult Generate(PasswordOptions options)
        {
            string password = GeneratePassword(options);
            ViewBag.GeneratedPassword = password;
            return View("Index", options);
        }

        private string GeneratePassword(PasswordOptions options)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            StringBuilder characterSet = new StringBuilder(lowercase);

            if (options.IncludeUppercase)
                characterSet.Append(uppercase);
            if (options.IncludeNumbers)
                characterSet.Append(numbers);
            if (options.IncludeSpecialCharacters)
                characterSet.Append(specialChars);

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < options.Length; i++)
            {
                int index = random.Next(characterSet.Length);
                password.Append(characterSet[index]);
            }

            return password.ToString();
        }
    }
}
