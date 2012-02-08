using System;

namespace PumpLogix
{
    public class CostDisplay : IShowCost
    {
        public void AddAmountDispensed(double amount)
        {
            AmountDispensed += amount;
        }

        public double AmountDispensed { get; private set; }

        public double GetCost(double amount, double costPerGallon)
        {
            return amount * costPerGallon;
        }
    }
}
