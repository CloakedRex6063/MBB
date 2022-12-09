using System.Collections;
using Managers;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
// ReSharper disable Unity.InefficientPropertyAccess


namespace GameObjects
{
    public class Cannon : MonoBehaviour
    {
        // Stores the aim assist line and the rotatable objects
        public Transform rotate;
        public GameObject aimLineGo;
        public TextMeshPro balls;
    
        // Speed of the ball and interval of shooting
        [Header("Ball")]
        public float ballspeed = 10f;
        public float shootspeed = 0.1f;
    
        // Managers
        private GameManager _gm;
        private PoolManager _pm;
    
        // Ball related
        private Vector3 _ballpos;

        // How far the cannon should move in the first randomization
        public float startmaxpos = 1.5f;
        public float maxpos = 4.5f;

        void Awake()
        {
            // Make aim line disappear
            aimLineGo.SetActive(false);
            _gm = FindObjectOfType<GameManager>();
            _pm = FindObjectOfType<PoolManager>();
        }
    
        private void Start()
        {
            var random = Random.Range(-startmaxpos, startmaxpos);
            transform.position = new Vector3(random, transform.position.y, 0);
        }

        private void Update()
        {
            balls.text = GetPlayBallCount().ToString();
        }

        // when mouse button is released
        public void DoOnButtonUp()
        {
            // Make aim line disappear
            aimLineGo.SetActive(false);
        }

        // when mouse button is held down
        public void DoOnButtonHold(float angle)
        {
            // Make aim line disappear
            aimLineGo.SetActive(true);
            // Rotate the aim line
            rotate.rotation = Quaternion.Euler(0f,0f,angle);
        }

        // Get the number of balls for the round
        public int GetBallCount()
        {
            return _pm.GetBallCount();
        }

        public void BallRemoved(Vector3 transformPosition)
        {
            
            // check if first ball is removed
            if (_pm.GetActiveBallCount() == GetBallCount())
            {
                // store the ball out position
                _ballpos = transformPosition;
            }
            // check if all balls are removed
            if (_pm.GetActiveBallCount() == 1)
            {
                // change to prep state
                _gm.ChangeState(GameManager.GameState.Prep);
                // move the cannon to the stored ball out position
                transform.position = _ballpos;
            }
        }
    
        /// <summary>
        /// Shoots the balls while looping through the amount of balls
        /// </summary>
        /// <returns></returns>
        public IEnumerator LoopShoot()
        {
            for (int i = 0; i < _pm.GetBallCount(); i++)
            {
                // Fetch all the balls and set them to the cannons position
                GameObject ball = _pm.FetchBallsFromList();
                ball.transform.position = rotate.position;
                // wait till all of the balls are moved
                yield return null;
                // add force to move the balls in the direction the cannon is facing
                ball.GetComponent<Rigidbody2D>().AddForce(rotate.up * ballspeed,ForceMode2D.Impulse);
                // wait for the interval before shooting again
                yield return new WaitForSeconds(shootspeed);
            }
            // wait before resetting the cannon angle
            yield return new WaitForSeconds(0.2f);
            // Change state of the game state to action so input manager gets disabled
            _gm.ChangeState(GameManager.GameState.Action);
            ResetCannonAngle();
        }

        // Reset the cannon angle to 0
        private void ResetCannonAngle()
        {
            rotate.rotation = Quaternion.identity;
        }

        private int GetPlayBallCount()
        {
            return _pm.GetBallCount()-_pm.GetActiveBallCount();
        }

        public void DoOnPickup()
        {
            _pm.Spawn();
        }
        
    }
}
