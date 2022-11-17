using System;

namespace smartSchool.API.Helpers
{
    public static class DateTimeExtensions
    {
        public static int IdadeAtual(this DateTime dateTime)
        {
            var dataCorrente = DateTime.UtcNow;

            int idade = dataCorrente.Year - dateTime.Year;

            if (dataCorrente < dateTime.AddYears(idade))
                idade--;

            return idade;
        }
    }
}