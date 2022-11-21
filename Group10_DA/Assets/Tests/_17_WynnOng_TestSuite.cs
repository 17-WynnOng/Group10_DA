using System.Collections;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.TestTools;

namespace Tests
{
   
    public class _17_WynnOng_TestSuite 
    { 

        private Player player;
        private GameObject testObject;
        
        [SetUp]
        public void SetUp()
        {
            testObject = GameObject.Instantiate(new GameObject());
            
        }

        [Test]
        public void PlayerMoveLeft()
        {
            Vector3 MoveLeft = testObject.transform.position -= new Vector3(10, 0, 0);

            Assert.AreNotEqual(MoveLeft, testObject.transform.position.x);
        }

        [Test]
        public void PlayerMoveRight()
        {
            Vector3 MoveRight = testObject.transform.position += new Vector3(10, 0, 0);

            Assert.AreNotEqual(MoveRight, testObject.transform.position.x);
        }

        [Test]
        public void PlayerShoot()
        {
            int CurrentAmmo;
            int MaxAmmo = 20;

            CurrentAmmo = MaxAmmo;

            CurrentAmmo--;

            Assert.Less(CurrentAmmo, MaxAmmo);
        }

        [Test]
        public void PlayerReload()
        {
            int CurrentAmmo = 10;
            int MaxAmmo = 20;

            if (CurrentAmmo < MaxAmmo)
            {
                CurrentAmmo = MaxAmmo;
            }

            Assert.AreEqual(CurrentAmmo, MaxAmmo);
        }
    }
}
