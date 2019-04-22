using System;

namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        
        [Test]
        public void PhoneConstructorSetCorrectly()
        {
            var phone = new Phone("Make", "Model");
            Assert.AreEqual("Make",phone.Make);
            Assert.AreEqual("Model",phone.Model);
        }
        [Test]
        public void PropertyMakeThrowArgumentException()
        {
                Assert.Throws<ArgumentException>(() => new Phone("", "Model"));
        }
        [Test]
        public void PropertyModelThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Make", ""));
        }

        [Test]
        public void MethodAddContactWorkCorrectly()
        {
            var phone = new Phone("Make", "Model");
            phone.AddContact("Pesho","0000");

            Assert.AreEqual(1,phone.Count);
        }
        [Test]
        public void MethodAddContactThrowInvalidOperationException()
        {
            var phone = new Phone("Make", "Model");
            phone.AddContact("Pesho", "0000");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "0000"));
        }

        [Test]
        public void MethodCallWorkCorrectly()
        {
            var phone = new Phone("Make", "Model");
            phone.AddContact("Pesho", "0000");
            Assert.AreEqual("Calling Pesho - 0000...",phone.Call("Pesho"));
        }
        [Test]
        public void MethodCallThrowInvalidOperationException()
        {
            var phone = new Phone("Make", "Model");
            phone.AddContact("Pesho", "0000");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }

    }
}