using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;

namespace FireEnemy
{
    public class Wind : MonoBehaviour, IExtinguisher
    {
        [SerializeField]
        private float windPower = 1.0f;
        [SerializeField]
        private float putOutFireVelocity = 1.0f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExtinguishFire(FireCore fire)
        {

        }
        void OnTriggerStay2D(Collider2D col)
        {

            Rigidbody2D rig = col.GetComponent<Rigidbody2D>();
            if (rig != null)
            {
                Vector2 windDir = new Vector2(-transform.localScale.x * windPower, 0);
                rig.AddForce(windDir);
            }
        }
    }
}