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
        private bool UpgradeMenu = false;

        [Test]
        public void StartBtn()
        {
            SceneManager.LoadScene("GameScene");

            Assert.AreEqual(SceneManager.GetSceneByBuildIndex(1).name, "GameScene");
        }

        [Test]
        public void InstructionBtn()
        {
            SceneManager.LoadScene("CreditScene");

            Assert.AreEqual(SceneManager.GetSceneByBuildIndex(2).name, "CreditScene");
        }

        [Test]
        public void BackBtn()
        {
            SceneManager.LoadScene("Menu");

            Assert.AreEqual(SceneManager.GetSceneByBuildIndex(0).name, "Menu");
        }

        [Test]
        public void NextWaveBtn()
        {
            Assert.AreEqual(UpgradeMenu, false);
        }
    }
}
