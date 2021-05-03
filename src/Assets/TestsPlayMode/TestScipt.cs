using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScipt
    {

        [UnityTest]
        public IEnumerator TestBasic()
        {
            GameObject gameGameObject =
                 MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Notes"));
            NoteScroller bs = gameGameObject.GetComponent<NoteScroller>();
            yield return null;
            Assert.IsNotNull(bs);
        }

        [UnityTest]
        public IEnumerator TestNoteHit()
        {
            GameObject gameObject =
                 MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
            GameManager gm = gameObject.GetComponent<GameManager>();
            gameObject =
                 MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/CollisionDetector"));
            CollisionDetector cd = gameObject.GetComponent<CollisionDetector>();
            cd.NoteHit();
            yield return null;
            Assert.AreEqual(gm.currentScore,gm.scorePerNote);
        }

        [UnityTest]
        public IEnumerator TestNoteHit2()
        {
            GameManager gm = new GameManager();
            CollisionDetector cd = new CollisionDetector();
            cd.NoteHit();
            yield return null;
            Assert.AreEqual(gm.currentScore, gm.scorePerNote);
        }
    }
}
