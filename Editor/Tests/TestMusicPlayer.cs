using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
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

        [Test]
        public void Test_MusicPlayerReturnsAllFilesWithinDirectory()
        {
            IcedCoffee.MusicLoader ml = new IcedCoffee.MusicLoader("/Music");

            List<string> files = ml.LoadAudioFileNames();

            Assert.AreEqual(files, new List<string> { "Duo", "Urban" });
        }

        [Test]
        public async void Test_MusicPlayerReturnsAllFilesWithinDirectory_StressTest()
        {
            IcedCoffee.MusicLoader ml = new IcedCoffee.MusicLoader("/Music");

            float t = System.DateTime.Now.Millisecond;
            List<string> files = await System.Threading.Tasks.Task.Run(ml.LoadAudioFileNames);
            float fin = System.DateTime.Now.Millisecond - t;
            if (fin < 250)
            {
                Assert.Pass("IcedCoffee.MusicLoader.LoadAudioFileNames passed Stress Test in time: " + fin);
            }
            else
            {
                Assert.Fail("IcedCoffee.MusicLoader.LoadAudioFileNames failed Stress Test in time: " + fin);
            }
        }
    }
}
