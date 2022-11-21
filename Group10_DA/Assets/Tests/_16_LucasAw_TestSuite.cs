using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class _16_LucasAw_TestSuite
    {
        private float PlayerDMG = 1f;
        private float PlayerSPEED = 4f;
        private float PlayerRELOAD = 2f;
        private float PlayerAMMO = 12f;

        [Test]
        public void UpgradeDmg()
        {
            if(PlayerDMG < 5f)
            {
                PlayerDMG = 1f + 1f;
                Assert.AreEqual(PlayerDMG, 2);
            }        
        }

        [Test]
        public void UpgradeSpeed()
        {
            if(PlayerSPEED < 8)
            {
                PlayerSPEED = 4f + 0.5f;
                Assert.AreEqual(PlayerSPEED, 4.5f);
            }            
        }

        [Test]
        public void UpgradeReload()
        {
            if(PlayerRELOAD > 0.8f)
            {
                PlayerRELOAD = 2f - 0.3f;
                Assert.AreEqual(PlayerRELOAD, 1.7f);
            }           
        }

        [Test]
        public void UpgradeAmmo()
        {
            if (PlayerAMMO < 18f)
            {
                PlayerAMMO = 12f + 2f;
                Assert.AreEqual(PlayerAMMO, 14f);
            }
        }
    }
}
