using System.Collections;
using UnityEngine;

namespace GameObjects.Bricks
{
    public class ExplosiveBrick : Brick
    {
        public float radius;
        public int explosionDamage;
        public bool exploded;
        public bool nuke;
        public GameObject vfx;
        public LayerMask brickLayer;

        protected override void Awake()
        {
            base.Awake();
            vfx.transform.parent = null;
        }

        public override void Die()
        {
            if (!exploded)
            {
                exploded = true;
                Explode();
            }
        }
        
        void Explode()
        { 
            // ReSharper disable once Unity.PreferNonAllocApi
            Collider2D[] bricks = Physics2D.OverlapCircleAll(transform.position, radius, brickLayer);
            vfx.SetActive(true);
            StartCoroutine(Timer(bricks));
        }
        IEnumerator Timer(Collider2D[] bricks)
        {
            float time = nuke ? 0.4f : 0;
            yield return new WaitForSeconds(time);
            foreach (var t in bricks)
            {
                if (t != null)
                {
                    t.GetComponent<Brick>().Damage(explosionDamage);
                }
            }
            base.Die();
        }
    }
}