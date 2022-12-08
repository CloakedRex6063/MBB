using UnityEngine;

namespace GameObjects.Bricks
{
    public class ExplosiveBrick : Brick
    {
        public float radius;
        public int explosionDamage;
        private bool exploded;
        public LayerMask brickLayer;

        protected override void Die()
        {
            if (!exploded)
            {
                exploded = true;
                Explode();
                base.Die();
            }
        }

        void Explode()
        { 
            Collider2D[] Bricks = Physics2D.OverlapCircleAll(transform.position, radius, brickLayer);
            foreach (var t in Bricks)
            {
                t.GetComponent<Brick>().Damage(explosionDamage);
            }
        }
    }
}