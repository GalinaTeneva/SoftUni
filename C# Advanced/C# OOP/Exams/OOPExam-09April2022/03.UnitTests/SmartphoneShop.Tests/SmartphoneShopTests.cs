using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        private string modelName = "IPhone 13 Pro Max";
        private int maxBatteryCharge = 100;
        private int capacity = 3;

        [SetUp]
        public void SetUp()
        {
            this.smartphone = new Smartphone(modelName, maxBatteryCharge);
            this.shop = new Shop(capacity);
        }

       [Test]
       public void Test_CtorIsSettingCorrectly()
        {
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        public void Test_NegativeOrZeroCapacityShouldThrow(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               shop = new Shop(capacity);
           });
        }

        [Test]
        public void Test_AddSmartphoneShouldWork()
        {
            this.shop.Add(this.smartphone);

            Assert.AreEqual(1, this.shop.Count); 
        }

        [Test]
        public void Test_DuplicateSmartphonesShouldNotBeallowed()
        {
            this.shop.Add(this.smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.shop.Add(this.smartphone);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.shop.Add(new Smartphone(this.modelName, 300));
            });
        }

        [Test]
        public void Test_PhoneCanNotBeAddedWhenCapacityIsFull()
        {
            this.shop.Add(new Smartphone("LLL", 20));
            this.shop.Add(new Smartphone("PPP", 20));
            this.shop.Add(new Smartphone("MMM", 20));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.shop.Add(this.smartphone);
            });
        }

        [Test]
        public void Test_RemoveSmartphoneShouldWork()
        {
            this.shop.Add(this.smartphone);
            this.shop.Remove(this.modelName);

            Assert.AreEqual(0, this.shop.Count);
        }

        [Test]
        public void Test_RemoveSmartphoneShouldThrowWhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.shop.Remove(modelName);
            });
        }

        [Test]
        public void Test_TestPhoneShowldReduceBatteryCharge()
        {
            this.shop.Add(this.smartphone);
            this.shop.TestPhone(modelName, 50);

            Assert.AreEqual(maxBatteryCharge - 50, this.smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_TestPhoneShouldThrowWhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.shop.TestPhone(modelName, 20);
            });
        }

        [Test]
        public void Test_TestPhoneShouldThrowWhenPhoneBatteryIsNotEnough()
        {
            this.shop.Add(this.smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.shop.TestPhone(modelName, maxBatteryCharge + 1);
            });
        }

        [Test]
        public void Test_ChargePhoneShouldThrowWhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.shop.ChargePhone(modelName);
            });
        }

        [Test]
        public void Test_ChargePhoneShouldSetBatteryToMax()
        {
            this.shop.Add(this.smartphone);
            this.shop.TestPhone(modelName, 80);

            this.shop.ChargePhone(modelName);

            Assert.AreEqual(maxBatteryCharge, smartphone.CurrentBateryCharge);
        }
    }
}