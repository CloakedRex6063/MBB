using UnityEngine;

namespace GameObjects.Bricks
{
    public class ExplosiveBrick : Brick
    {
        public float radius;
        public int explosionDamage;
        private bool _exploded;
        public LayerMask brickLayer;

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
                t.GetComponent<Brick>().Damage(explosionDamage);
            }
        }
    }
}