using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireEnemy
{
    // ToDo:Implement the behavior of the water if collide stone
    public class Water : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

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
            }
        }



    }
}
