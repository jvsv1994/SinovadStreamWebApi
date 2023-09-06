using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Transversal.Common;
using System.Globalization;
using System.Text;

namespace SinovadDemo.Application.Shared
{
    public class SharedService
    {
        public MyConfig _config;

        public SharedService(IOptions<MyConfig> config)
        {
            _config = config.Value;
        }

        public string GetFormattedText(string input)
        {
            return Simplify(input).Replace(" ", "").Replace(".", "").Replace(":", "").Replace(",", "").Replace("-", "").Replace("!", "").Replace("¡", "").Replace("?", "").Replace("¿", "").Trim().ToUpper();
        }

        private static string Simplify(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);

                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
