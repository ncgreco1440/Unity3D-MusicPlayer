using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestMusicPlayerScene
    {
        GameObject testGameObject = null;
        Soundtrack soundtrack = null;

        [SetUp]
        public void SetUp()
        {
            SetupScene();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestMusicPlayerSceneWithEnumeratorPasses()
        {
            yield return new WaitForSeconds(1);

            IcedCoffee.MusicLoader loader = soundtrack.loader;

            Assert.IsNotNull(loader);
        }

        private void SetupScene()
        {
            testGameObject = new GameObject("TestGameObject", typeof(Soundtrack));
            soundtrack = testGameObject.GetComponent<Soundtrack>();
        }
    }
}
