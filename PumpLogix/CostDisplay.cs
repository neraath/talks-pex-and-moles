using System;

namespace PumpLogix
{
    public class CostDisplay : IShowCost
    {
        public void AddAmountDispensed(double amount)
        {
            AmountDispensed += amount;
            throw new Exception("Cannot connect to device output.");
        }

        public double AmountDispensed { get; private set; }

        public double GetCost(double amount, double costPerGallon)
        {
            return amount * costPerGallon;
        }
    }
}
