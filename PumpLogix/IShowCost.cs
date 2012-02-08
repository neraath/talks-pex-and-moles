namespace PumpLogix
{
    public interface IShowCost
    {
        void AddAmountDispensed(double amount);
        double AmountDispensed { get; }
        double GetCost(double amount, double costPerGallon);
    }
}
