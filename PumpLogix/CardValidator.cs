using System;

namespace PumpLogix
{
    public class CardValidator
    {
        public static bool IsCardNumberValid(string cardNumber)
        {
            // <pex>
            if (cardNumber == (string)null)
                throw new ArgumentNullException("cardNumber");
            // </pex>

            // Minimum threshold is 15 digits.
            if (cardNumber.Length < 15)
                return false;

            if (!System.Text.RegularExpressions.Regex.IsMatch(cardNumber, "^[0-9]{15,16}$"))
                throw new ArgumentException("The card number must consist of only digits.");

            // Use the LUHN formula to verify the CC number.
            int startingPos = cardNumber.Length - 2;
            int summation = 0;
            for (int i = startingPos; i >= 0; i-=2)
            {
                int valAtPos = int.Parse(cardNumber[i].ToString());
                int doubleVal = valAtPos*2;
                if (doubleVal >= 10)
                {
                    doubleVal -= 10;
                    summation += 1;
                }

                summation += doubleVal;
            }

            for (int i = startingPos + 1; i >= 0; i-=2)
            {
                int valAtPos = int.Parse(cardNumber[i].ToString());
                summation += valAtPos;
            }

            // We should have a value that's mod10.
            return summation%10 == 0;
        }

        public static bool IsCvvCodeValid(string cvvCode)
        {
            if (string.IsNullOrEmpty(cvvCode)) throw new ArgumentNullException("cvvCode");
            if (cvvCode.Length < 3 || cvvCode.Length > 4) return false;
            return true;
        }
    }
}
