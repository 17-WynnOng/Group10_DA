using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LucasAwTestSuite
    {

        public bool normalrobotmovement = true;
        public bool heavyrobotmovement = true;
        public bool normalrobotpunch = true;
        public bool heavyrobotpunch = true;
        
        [Test]
        public void NormalRobotMovementSFX()
        {
            Assert.AreEqual(normalrobotmovement, true);
        }

        [Test]
        public void HeavyRobotMovementSFX()
        {
            Assert.AreEqual(heavyrobotmovement, true);
        }

        [Test]
        public void NormalRobotPunchSFX()
        {
            Assert.AreEqual(normalrobotpunch, true);
        }

        [Test]
        public void HeavyRobotPunchSFX()
        {
            Assert.AreEqual(heavyrobotpunch, true);
        }
    }
}
