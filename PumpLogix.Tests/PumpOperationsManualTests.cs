using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PumpLogix.Moles;

namespace PumpLogix.Tests
{
    [TestClass]
    public class PumpOperationsManualTests
    {
        private PumpOperations pumpOps;
        
        [TestInitialize]
        public void InitializeTests()
        {
            this.pumpOps = new PumpOperations();
        }

        [TestMethod, HostType("Moles")]
        public void WhenPumpingSucceedsPumpingStops()
        {
            // Arrange.
            bool isPumping = false;
            MValveController.BehaveAsNotImplemented();
            MValveController.AllInstances.OpenValveFuelType = (fType, instance) => { };
            MValveController.AllInstances.CloseValveFuelType = (fType, instance) => { };
            MValveController.AllInstances.BeginPumping = (instance) => { isPumping = true; };
            MValveController.AllInstances.StopPumping = (instance) => { isPumping = false; };
            MValveController.AllInstances.ReadAmountDispensedFuelType = (fType, instance) => 5.0;

            // Act.
            this.pumpOps.BeginPumping(FuelType.Regular);

            // Assert.
            Assert.IsFalse(isPumping);
        }

        [TestMethod, HostType("Moles")]
        public void WhenPumpingFailsRequestToStopPumpingStillOccurs()
        {
            // Arrange.
            bool requestToStopPumping = false;
            MValveController.BehaveAsNotImplemented();
            MValveController.AllInstances.OpenValveFuelType = (fType, instance) => { };
            MValveController.AllInstances.CloseValveFuelType = (fType, instance) => { };
            MValveController.AllInstances.BeginPumping = (instance) =>
                                                             {
                                                                 throw new InvalidOperationException();
                                                             };
            MValveController.AllInstances.StopPumping = (instance) => { requestToStopPumping = true; };
            MValveController.AllInstances.ReadAmountDispensedFuelType = (fType, instance) => 5.0;

            // Act.
            this.pumpOps.BeginPumping(FuelType.Regular);

            // Assert.
            Assert.IsTrue(requestToStopPumping);
        }

        [TestMethod, HostType("Moles")]
        public void WhenPumpingSucceedsValveIsNeverLeftOpen()
        {
            bool isOpen = false;
            MValveController.BehaveAsNotImplemented();
            MValveController.AllInstances.OpenValveFuelType = (fType, instance) => { isOpen = true; };
            MValveController.AllInstances.CloseValveFuelType = (fType, instance) => { isOpen = false; };
            MValveController.AllInstances.BeginPumping = (instance) => { };
            MValveController.AllInstances.StopPumping = (instance) => { };
            MValveController.AllInstances.ReadAmountDispensedFuelType = (fType, instance) => 5.0;
            this.pumpOps.BeginPumping(FuelType.Regular);
            Assert.IsFalse(isOpen);
        }

        [TestMethod, HostType("Moles")]
        public void WhenPumpingFailsValveIsNeverLeftOpen()
        {
            bool isOpen = false;
            MValveController.BehaveAsNotImplemented();
            MValveController.AllInstances.OpenValveFuelType = (fType, instance) => { isOpen = true; };
            MValveController.AllInstances.CloseValveFuelType = (fType, instance) => { isOpen = false; };
            MValveController.AllInstances.BeginPumping = (instance) => { throw new InvalidOperationException(); };
            MValveController.AllInstances.StopPumping = (instance) => { };
            this.pumpOps.BeginPumping(FuelType.Regular);
            Assert.IsFalse(isOpen);
        }

    }
}
