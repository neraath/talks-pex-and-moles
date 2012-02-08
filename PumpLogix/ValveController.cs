using System;

namespace PumpLogix
{
    public sealed class ValveController
    {
        private int comPort;
        private bool isPumping;

        public ValveController(int comPortToValve)
        {
            this.comPort = comPortToValve;
        }

        public void OpenValve()
        {
            throw new Exception("Not connected to valve.");
        }

        public void CloseValve()
        {
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

        public double ReadAmountDispensed()
        {
            throw new Exception("Not connected to valve.");
        }
    }
}
