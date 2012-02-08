using System;

namespace PumpLogix
{
    public class PumpOperations
    {
        private ValveController controller;
        private IShowCost costDisplay;

        public PumpOperations() : this(new CostDisplay(), new ValveController(1))
        {
        }

        public PumpOperations(IShowCost costDisplay, ValveController valveController)
        {
            this.controller = valveController;
            this.costDisplay = costDisplay;
        }

        public void BeginPumping(FuelType fuelType)
        {
            try
            {
                // Pump.
                this.controller.OpenValve(fuelType);
                this.controller.BeginPumping();

                // Monitor.
                double amountDispensed = this.controller.ReadAmountDispensed(fuelType);
                this.costDisplay.AddAmountDispensed(amountDispensed);
            }
            catch (Exception)
            {
            }
            finally
            {
                // Stop.
                this.controller.StopPumping();
                this.controller.CloseValve(fuelType);
            }
        }
    }
}
