using System.ComponentModel.DataAnnotations;

namespace EducaTesting.Domain
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _datetimeNowProvider;

        public DateInFutureAttribute() : this(() => DateTime.Now)
        { }

        public DateInFutureAttribute(Func<DateTime> datetimeNowProvider)
        {
            _datetimeNowProvider = datetimeNowProvider;
            ErrorMessage = "La fecha tiene que ser de hoy en adelante";
        }

        public override bool IsValid(object? value)
        {
            bool isValid = false;
            if (value is DateTime dateTime)
            {
                isValid = dateTime > _datetimeNowProvider();
            }

            return isValid;
        }
    }
}
