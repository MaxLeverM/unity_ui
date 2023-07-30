using System.Numerics;

namespace RedPanda.Project.Helpers
{
    public static class UIHelper
    {
        private static readonly string[] Postfix = new[] {"K", "M", "B", "T"};
        private const long MinConvertFrom = 1000;

        public static string CurrencyToString(BigInteger amount, int digits = 1, int convertFrom = 0)
        {
            string result = amount.ToString();
            if (amount <= convertFrom || amount <= 0 || amount < MinConvertFrom)
            {
                return result;
            }

            for (int i = 1; i <= Postfix.Length; i++)
            {
                var number = BigInteger.Pow(1000, i);
                if ((amount >= number && amount < BigInteger.Pow(1000, i + 1)) || i == Postfix.Length)
                {
                    var divRes = BigInteger.DivRem(amount, number, out var remainder);
                    result = divRes.ToString();
                    if (remainder != 0)
                    {
                        var rounded = remainder / (number / (BigInteger.Pow(10, digits)));
                        if (rounded != 0)
                        {
                            result += $".{rounded}";
                        }
                    }

                    result += Postfix[i - 1];
                    break;
                }
            }
            return result;
        }
    }
}