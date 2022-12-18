using UnityEngine;

namespace GameObjects
{
    public class Ball : MonoBehaviour
    {
        private Cannon _cannon;
        private BottomLine _bl;
        private ParticleSystem _vfx;
        private AudioSource _hitaudio;

        // Start is called before the first frame update
        private void Awake()
        {
            // Find the game manager and store a reference to it
            _cannon = FindObjectOfType<Cannon>();

            // Find the game manager and store a reference to it
            _bl = FindObjectOfType<BottomLine>();
            
            // Find the vfx particle
            _vfx = GetComponentInChildren<ParticleSystem>();
            
            // Find the audio component
            _hitaudio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        private void Update()
        {
            // check if ball has gone below the bottom line
            if (transform.position.y < _bl.transform.position.y)
            {
                float clampedPos = Mathf.Clamp(transform.position.x,-_cannon.maxpos, _cannon.maxpos);
                // set the cannon's x axis using the ball's x axis position
                _cannon.BallRemoved(new Vector3(clampedPos,_cannon.transform.position.y,0f));
                gameObject.SetActive(false);
            }
        }

        public void DoOnHitBrick(Vector2 position)
        {
            _vfx.transform.position = position;
            _vfx.Play();
            _hitaudio.Play();
        }
    }
}
