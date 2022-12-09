using Managers;
using TMPro;
using UnityEngine;

namespace GameObjects.Bricks
{
    public abstract class Brick : MonoBehaviour
    {
        [Header("HP")]
        public int maxHp;

        [Header("Sprites")] 
        // Sprite used when Hp is above 50%
        public Sprite fullHpSprite;
        // Sprite used when hp is 50% or below
        public Sprite halfHpSprite;

        // Keeps track if sprite needs to be changed
        bool _spriteChange; 
        float _currentHp;

        // Stores the sprite renderer component
        private SpriteRenderer _spriteRenderer;
        // Stores the game manager
        private GameManager _gm;
        // Stores the text component to show hp of the brick
        private TextMeshPro _tmp;
        private bool died;

        protected virtual void Awake()
        {
            // Find the game manager and store a reference to it
            _gm = FindObjectOfType<GameManager>();
            _tmp = GetComponentInChildren<TextMeshPro>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected virtual void Start()
        {
            _currentHp = maxHp;
            // Each brick is added to the game manager's brick count
            _gm.IncreaseBrickCount();
            _spriteRenderer.sprite = fullHpSprite;
            if (_tmp)
            {
                _tmp.text = maxHp.ToString();   
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            // Returns the ball component of the colliding object
            Ball colBall = col.gameObject.GetComponent<Ball>();
            // if there is a ball component
            if (colBall)
            {
                // damage the brick
                Damage(1);
            }
        }

        public void Damage(int damage)
        {
            // Decrease hp
            _currentHp -= damage;
            if (_tmp)
            { 
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                _tmp.text = _currentHp.ToString();   
            }
            else
            {
                _tmp.text = "0";   
            }
            

            if (_currentHp <= (maxHp*0.5f) && !_spriteChange)
            {
                _spriteChange = true;
                _spriteRenderer.sprite = halfHpSprite;
            }
            
            // if hp is now 0 or below 
            if (_currentHp <= 0)
            {
                if (!died)
                {
                    Die();
                    died = true;
                }
            }
        }

        protected virtual void Die()
        {
            // decrease the brick count
            _gm.DecreaseBrickCount();
            // destroy the brick
            Destroy(gameObject);
        }
    }
}

