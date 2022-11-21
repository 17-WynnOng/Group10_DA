using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class _11_Vanness_TestSuite
    {
        public bool MoveLeft = true;
        public bool MoveRight = true;
        public bool Shooting = true;
        public bool Reload = true;

        [Test]
        public void StartBtn()
        {
            
        }

        [Test]
        public void InstructionBtn()
        {
            SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
        }

        [Test]
        public void BackBtn()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }

        [Test]
        public void PlayerReload()
        {
            Assert.AreEqual(Reload, true);
        }
    }
}
