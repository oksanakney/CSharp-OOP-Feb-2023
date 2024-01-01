namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ctor()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            /* this.MemoryCapacity = memoryCapacity;
               this.AvailableMemory = memoryCapacity;
               this.Photos = 0;
               this.Applications = new List<string>(); */

            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void TakePhoto()
        {
            /*public bool TakePhoto(int photoSize)
        {
            if (photoSize <= this.AvailableMemory)
            {
                this.AvailableMemory -= photoSize;
                this.Photos++;
                return true;
            }
            return false;
        }*/
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int photoSize = 100;

            bool photoTaken = device.TakePhoto(photoSize);

            Assert.IsTrue(photoTaken);
            Assert.AreEqual(memoryCapacity - photoSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void Device_TakePhoto_ShouldreturnFalseIfNotEnoughMemory()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int photoSize = 3000;

            bool photoTaken = device.TakePhoto(photoSize);
            Assert.IsFalse(photoTaken);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
        }
        [Test]
        /*public string InstallApp(string appName, int appSize)
        {
            if (appSize <= this.AvailableMemory)
            {
                this.AvailableMemory -= appSize;
                this.Applications.Add(appName);
                return $"{appName} is installed successfully. Run application?";
            }
            else
            {
                throw new InvalidOperationException("Not enough available memory to install the app.");
            }
        }*/
        public void Device_InstallApp_ShouldReduceAvailableMemoryAndAddAppToList()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int appSize = 500;
            string appName = "MyApp";

            string result = device.InstallApp(appName, appSize);

            Assert.AreEqual($"{appName} is installed successfully. Run application?", result);
            Assert.AreEqual(memoryCapacity - appSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.IsTrue(device.Applications.Contains(appName));
        }
        [Test]
        public void Device_InstallApp_ShouldThrowExceptionIfNotEnoughMemory()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int appSize = 3000;
            string appName = "MyApp";

            Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, appSize));
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void Device_FormatDevice_ShouldResetProperties()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyApp", 500);

            device.FormatDevice();

            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }
        [Test]
        public void Result()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyApp", 300);
            device.InstallApp("MyApp2", 500);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - photoSize - 300 - 500} MB");
            sb.AppendLine($"Photos Count: 1");
            sb.AppendLine($"Applications Installed: MyApp, MyApp2");

            string result = sb.ToString().TrimEnd();
            string status = device.GetDeviceStatus();

            Assert.AreEqual(status, result);

        }
    }
}