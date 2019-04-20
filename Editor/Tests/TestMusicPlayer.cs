using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestMusicPlayer
    {
        [Test]
        public void Test_MusicPlayerExists()
        {
            IcedCoffee.MusicLoader ml = new IcedCoffee.MusicLoader();

            Assert.IsNotNull(ml);
        }

        [Test]
        public void Test_MusicPlayerHasSetDefaultStreamingAssetsPath()
        {
            IcedCoffee.MusicLoader ml = new IcedCoffee.MusicLoader();

            Assert.AreEqual(ml.DataPath, Application.streamingAssetsPath);
        }

        [Test]
        public void Test_MusicPlayerHasSetOverriddenStreamingAssetsPath()
        {
            IcedCoffee.MusicLoader ml = new IcedCoffee.MusicLoader("/Soundtrack");

            Assert.AreEqual(ml.DataPath, Application.streamingAssetsPath + "/Soundtrack");
        }
    }
}
