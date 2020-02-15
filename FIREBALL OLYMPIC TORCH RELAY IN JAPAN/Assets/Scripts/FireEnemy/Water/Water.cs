using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireEnemy
{
    // ToDo:Implement the behavior of the water if collide stone
    public class Water : MonoBehaviour
    {
        private ParticleSystem particle;
        // Start is called before the first frame update
        void Start()
        {
            particle = GetComponent<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnParticleCollision(GameObject col)
        {
            IExtinguishable fire = col.GetComponent(typeof(IExtinguishable)) as IExtinguishable;
            if (fire != null)
            {
                // Debug.Log("Touch Water");
                fire.ExtinguishFire();
                Destroy(this.gameObject);
            }
            if (col.gameObject.tag == "Rock")
            {
                particle.startLifetime = 0.2f;
            }
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            IExtinguishable fire = col.GetComponent(typeof(IExtinguishable)) as IExtinguishable;
            if (fire != null)
            {
                fire.ExtinguishFire();
            }
            // Destroy(this.gameObject);
            if (col.gameObject.tag == "Ground")
            {
                Destroy(this.gameObject);
            }
        }



    }
}
