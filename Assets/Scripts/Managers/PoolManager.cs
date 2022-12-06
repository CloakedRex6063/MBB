using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        private List<GameObject> _balls;
        public GameObject ball;
        public int ballcount;
        private void Awake()
        {
            // create a new list of size ball count
            _balls = new List<GameObject>(ballcount);
            //loop to spawn balls
            for (int i = 0; i < ballcount; i++)
            {
                // spawn the ball
                GameObject spawned = Instantiate(ball);
                // add to the list
                _balls.Add(spawned);
                // set it inactive
                spawned.SetActive(false);
            }
        }

        public GameObject FetchBallsFromList()
        {
            if (_balls.Count > 0)
            {
                foreach (var t in _balls)
                {
                    if (!t.activeInHierarchy)
                    {
                        t.SetActive(true);
                        return t;
                    }
                }
            }
            return null;
        }
    }
}
