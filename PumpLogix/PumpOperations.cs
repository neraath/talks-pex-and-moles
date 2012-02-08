namespace PumpLogix
{
    public class PumpOperations
    {
        private ValveController controller;
        private CostDisplay costDisplay;

        public PumpOperations()
        {
            this.controller = new ValveController(1);
            this.costDisplay = new CostDisplay();
        }

        public void BeginPumping(FuelType fuelType)
        {
            // Pump.
            this.controller.OpenValve();
            this.controller.BeginPumping();

            // Monitor.
            double amountDispensed = this.controller.ReadAmountDispensed();
            this.costDisplay.AddAmountDispensed(amountDispensed);

            // Stop.);
            this.controller.StopPumping();
            this.controller.CloseValve();
        }
    }
}
