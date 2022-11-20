using System.Collections;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.TestTools;

namespace Tests
{
   
    public class WynnOngTestSuite 
    { 
        public bool MoveLeft = true;
        public bool MoveRight = true;
        public bool Shooting = true;
        public bool Reload = true;

        [Test]
        public void PlayerMoveLeft()
        {
            Assert.AreEqual(MoveLeft, true);
        }

        [Test]
        public void PlayerMoveRight()
        {
            Assert.AreEqual(MoveRight, true);
        }

        [Test]
        public void PlayerShoot()
        {
            Assert.AreEqual(Shooting, true);
        }

        [Test]
        public void PlayerReload()
        {
            Assert.AreEqual(Reload, true);
        }
    }
}
