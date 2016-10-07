﻿using System.Configuration;
using NUnit.Framework;

namespace Nexmo.Api.Test.Integration
{
    [TestFixture]
    public class SmsTest
    {
        [Test]
        public void should_send_sms()
        {
            var results = SMS.Send(new SMS.SMSRequest
            {
                from = ConfigurationManager.AppSettings["nexmo_number"],
                to = ConfigurationManager.AppSettings["test_number"],
                text = "this is a test"
            });
            Assert.AreEqual(ConfigurationManager.AppSettings["test_number"], results.messages[0].to);
            Assert.AreEqual("0", results.messages[0].status);
        }
    }
}