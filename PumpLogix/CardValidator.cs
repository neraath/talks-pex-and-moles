using System;

namespace PumpLogix
{
    public class CardValidator
    {
        public static bool IsCardNumberValid(string cardNumber)
        {
            // Minimum threshold is 15 digits.
            if (cardNumber.Length < 15)
            {
                return false;
            }

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
    }
}
