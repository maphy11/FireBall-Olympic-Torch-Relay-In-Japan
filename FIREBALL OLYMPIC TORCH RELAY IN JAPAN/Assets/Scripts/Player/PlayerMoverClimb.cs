using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public class PlayerMoverClimb : PlayerMoverBase
    {
        private bool climbing;
        [SerializeField] private float climbSpeed = 20.0f;

        protected override void MoveVirticle(Vector2 input)
        {
            if (climbing)
            {
                ClimbLadder(input);
            }
            else
            {
                base.MoveVirticle(input);
            }
        }

        // Start is called before the first frame update
        protected override void Setup()
        {
            base.Setup();
            climbing = false;
        }

        protected override void UpdateMethod()
        {
            base.UpdateMethod();
        }

        private void ClimbLadder(Vector3 direction)
        {
            if (direction != null)
            {
                transform.position = transform.position + direction * climbSpeed * Time.deltaTime;
            }
        }

        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Ladder")
            {
                climbing = true;
                rig.gravityScale = 0;
                // float Xspeed = rig.velocity.x;
                // rig.velocity = new Vector2(Xspeed, 0);
                rig.velocity = Vector2.zero;
            }
        }


        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Ladder")
            {
                climbing = false;
                rig.gravityScale = 1;
            }

        }

    }
}
