using System.ComponentModel.DataAnnotations;

namespace MVC09Project
{
    public class DoNotHaveWords : ValidationAttribute
    {
        private string[] _words;
        public DoNotHaveWords(string[] words)
        {
            _words = words;
        }
        //protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        //{
        //    //var bad = new HashSet<string>(_words, StringComparer.InvariantCultureIgnoreCase);
        //    //var request = (CreateWeatherForecastRequest)validationContext.ObjectInstance;
        //    //if (string.IsNullOrEmpty(request.Summary)) return
        //    //ValidationResult.Success;
        //    //var words = new HashSet<string>(request.Summary.Split(" "),
        //    //StringComparer.InvariantCultureIgnoreCase);
        //    //foreach (var word in words)
        //    //{
        //    //    if (bad.Contains(word))
        //    //        return new ValidationResult("Описание содержит запрещенные слова", new[] { nameof(request.Summary) });
        //    //}
        //    //return ValidationResult.Success;
        //}

    }
}
