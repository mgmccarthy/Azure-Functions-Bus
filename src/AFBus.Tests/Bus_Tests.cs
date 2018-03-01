﻿using System;
using AFUtils.Tests.TestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AFBus.Tests
{
    [TestClass]
    public class Bus_Tests
    {
        readonly string SERVICENAME = "FAKESERVICE";

        [TestMethod]
        public void Bus_SendAsync_Nominal()
        {
            var message = new TestMessage()
                            { 
                                SomeData="asdf"
                            };

            IBus bus = new Bus();
            bus.SendAsync(message, SERVICENAME).Wait();

            var stringMessage = QueueReader.ReadFromQueue(SERVICENAME).Result;

            var finalMessage = JsonConvert.DeserializeObject<TestMessage>(stringMessage, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });

        }
    }
}