using System;
using System.Collections.Generic;

namespace PumpLogix
{
    public sealed class ValveController
    {
        private int comPort;
        private bool isPumping;
        private List<FuelType> openValves = new List<FuelType>();
        private Dictionary<FuelType, double> amountDispensed = new Dictionary<FuelType, double>();

        public ValveController(int comPortToValve)
        {
            this.comPort = comPortToValve;
        }

        public void OpenValve(FuelType fuelType)
        {
            this.openValves.Add(fuelType);
            amountDispensed.Add(fuelType, 0.0);
            throw new Exception("Not connected to valve.");
        }

        public void CloseValve(FuelType fuelType)
        {
            this.openValves.Remove(fuelType);
            throw new Exception("Not connected to valve.");
        }

        public void BeginPumping()
        {
            isPumping = true;
        }

        public void StopPumping()
        {
            isPumping = false;
        }

        public double ReadAmountDispensed(FuelType fuelType)
        {
            if (!amountDispensed.ContainsKey(fuelType)) return 0.0;
            return amountDispensed[fuelType];
            throw new Exception("Not connected to valve.");
        }
    }
}
