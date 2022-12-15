using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameObjects.Bricks
{
    public class ExplosiveBrick : Brick
    {
        public float radius;
        public int explosionDamage;
        private bool _exploded;
        public GameObject vfx;
        public LayerMask brickLayer;

        protected override void Awake()
        {
            base.Awake();
            vfx.transform.parent = null;
        }

        protected override void Die()
        {
            if (!_exploded)
            {
                _exploded = true;
                Explode();
                base.Die();
            }
        }
        
        void Explode()
        { 
            // ReSharper disable once Unity.PreferNonAllocApi
            Collider2D[] bricks = Physics2D.OverlapCircleAll(transform.position, radius, brickLayer);
            foreach (var t in bricks)
            {
                if (t != null)
                {
                    t.GetComponent<Brick>().Damage(explosionDamage);
                }
            }
            vfx.SetActive(true);
        }
    }
}