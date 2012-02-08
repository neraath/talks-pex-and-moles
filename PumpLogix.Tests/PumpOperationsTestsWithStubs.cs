using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PumpLogix.Moles;

namespace PumpLogix.Tests
{
    [TestClass]
    public class PumpOperationsTestsWithStubs
    {
        private PumpOperations pumpOps;
        private MValveController valveController;
        private SIShowCost costStub;

        [TestInitialize]
        public void InitializeTests()
        {
            this.costStub = new SIShowCost();
            this.valveController = new MValveController();
            this.pumpOps = new PumpOperations(costStub, valveController);
        }

        [TestMethod, HostType("Moles")]
        public void WhenSuccessfulPumpShouldUpdateCostController()
        {
            // Arrange.
            double amountDispensed = 5.0;
            this.valveController.BeginPumping = () => { };
            this.valveController.StopPumping = () => { };
            this.valveController.OpenValveFuelType = (ftype) => { };
            this.valveController.CloseValveFuelType = (ftype) => { };
            this.valveController.ReadAmountDispensedFuelType = (ftype) => amountDispensed;

            double amountDispensedToCostStub = 0.0;
            this.costStub.AddAmountDispensedDouble = (dispensedAmount) => amountDispensedToCostStub = dispensedAmount;

            // Act.
            this.pumpOps.BeginPumping(FuelType.Regular);

            // Assert.
            Assert.AreEqual(amountDispensed, amountDispensedToCostStub);
        }

        [TestMethod, HostType("Moles")]
        public void WhenPumpingUnsuccesfulShouldNotUpdateCostController()
        {
            // Arrange.
            this.valveController.OpenValveFuelType = (ftype) => { };
            this.valveController.CloseValveFuelType = (ftype) => { };
            this.valveController.BeginPumping = () => { throw new Exception(); };
            this.valveController.StopPumping = () => { };
            this.costStub.AddAmountDispensedDouble = (dispensedAmount) => Assert.Fail("This should never be reached.");

            // Act.
            this.pumpOps.BeginPumping(FuelType.Regular);
        }
    }
}
