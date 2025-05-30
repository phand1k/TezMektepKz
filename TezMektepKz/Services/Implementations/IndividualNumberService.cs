using TezMektepKz.Services.Interfaces;

namespace TezMektepKz.Services.Implementations
{
    public class IndividualNumberService : IIndividualNumberService
    {
        public Task<DateOnly?> GetBornDateFromIndividualNumber(string individualNumber)
        {
            if (string.IsNullOrEmpty(individualNumber) || individualNumber.Length != 12)
                return Task.FromResult<DateOnly?>(null);

            if (!individualNumber.All(char.IsDigit))
                return Task.FromResult<DateOnly?>(null);

            // ГГММДД (первые 6 цифр)
            string yearPart = individualNumber.Substring(0, 2);
            string monthPart = individualNumber.Substring(2, 2);
            string dayPart = individualNumber.Substring(4, 2);

            // 7-й символ определяет век и пол
            char centuryGender = individualNumber[6];

            int century;
            switch (centuryGender)
            {
                case '1':
                case '2':
                    century = 1800;
                    break;
                case '3':
                case '4':
                    century = 1900;
                    break;
                case '5':
                case '6':
                    century = 2000;
                    break;
                default:
                    return Task.FromResult<DateOnly?>(null); // Некорректный век
            }

            if (!int.TryParse(yearPart, out int year) ||
                !int.TryParse(monthPart, out int month) ||
                !int.TryParse(dayPart, out int day))
            {
                return Task.FromResult<DateOnly?>(null);
            }

            try
            {
                var date = new DateOnly(century + year, month, day);
                return Task.FromResult<DateOnly?>(date);
            }
            catch
            {
                return Task.FromResult<DateOnly?>(null); // Неверная дата
            }
        }


        public Task<bool> IsValid(string individualNumber)
        {
            if (string.IsNullOrEmpty(individualNumber) || individualNumber.Length != 12)
                return Task.FromResult(false);

            if (!individualNumber.All(char.IsDigit))
                return Task.FromResult(false);

            // Преобразуем ИИН в массив чисел
            int[] digits = individualNumber.Select(c => int.Parse(c.ToString())).ToArray();

            // Первый коэффициент для контрольной суммы
            int[] weights1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int sum1 = 0;
            for (int i = 0; i < 11; i++)
            {
                sum1 += digits[i] * weights1[i];
            }

            int controlDigit = sum1 % 11;

            // Если контрольная цифра 10 — пересчитываем с другим набором весов
            if (controlDigit == 10)
            {
                int[] weights2 = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 1, 2 };
                int sum2 = 0;
                for (int i = 0; i < 11; i++)
                {
                    sum2 += digits[i] * weights2[i];
                }

                controlDigit = sum2 % 11;
                if (controlDigit == 10)
                    return Task.FromResult(false); // такой ИИН считается недопустимым
            }

            return Task.FromResult(digits[11] == controlDigit);
        }

    }
}
