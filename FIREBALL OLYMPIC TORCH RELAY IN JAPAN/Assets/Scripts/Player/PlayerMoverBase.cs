using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;

namespace Player
{
    public class PlayerMoverBase : MonoBehaviour
    {

        //jason
        public AK.Wwise.Event JumpEvent;

        //Inspecter data
        [SerializeField] protected GameObject inputManager;
        [SerializeField] private float runMaxSpeed = 1.0f;
        [SerializeField] private float reachMaxSpeedTime = 1.0f;
        [SerializeField] private float reachRunStopTime = 1.0f;
        [SerializeField] private float jumpForce = 1.0f;

        //Component instances
        protected Rigidbody2D rig;
        protected IinputObserver inputObserver;

        private PlayerCore coreData;
        // other data
        private Vector3 runVel;

        private Vector3 scale;

        private bool isStadiumJump;
        void Start()
        {
            Setup();
        }
        void FixedUpdate()
        {
            if (PossibleToMove())
            {
                UpdateMethod();
                return;
            }
            if (coreData.state == PlayerState.ReachStadium)
            {
                return;
            }
            if (coreData.state == PlayerState.StadiumJump)
            {
                return;
            }

            coreData.speed = 0;
        }
        void Update()
        {
            if (coreData.state == PlayerState.ReachStadium)
            {
                if (coreData.isGround)
                {
                    Walk(Vector2.right);
                    return;
                }
            }
            if (coreData.state == PlayerState.StadiumJump)
            {
                if (isStadiumJump) { return; }
                StartCoroutine("StadiumLastAnimationMove");
                isStadiumJump = true;
                return;
            }
        }
        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.tag == "Ground")
            {
                coreData.isGround = false;
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "TopCollider")
            {
                coreData.isGround = false;
            }
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Ground")
            {
                if (coreData.isGround) { return; }
                coreData.isGround = true;
                rig.velocity = Vector2.zero;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "TopCollider")
            {
                if (coreData.isGround) { return; }
                coreData.isGround = true;
                rig.velocity = Vector2.zero;
            }
        }
        // The Setup
        // UpdateMethod
        // MoveVertical
        // MoveHorizontal
        // They need to inherit children class
        protected virtual void Setup()
        {
            isStadiumJump = false;
            coreData = GetComponent<PlayerCore>();
            inputObserver = inputManager.GetComponent(typeof(IinputObserver)) as IinputObserver;
            rig = GetComponent<Rigidbody2D>();
            scale = transform.localScale;
            runVel = Vector3.zero;
        }

        protected virtual void UpdateMethod()
        {
            Vector2 inputVertical = inputObserver.OnMoveVertical();
            Vector2 inputHorizontal = inputObserver.OnMoveHorizontal();
            MoveHorizontal(inputHorizontal);
            MoveVertical(inputVertical);
            coreData.speed = runVel.magnitude;
        }

        protected virtual void MoveVertical(Vector2 input)
        {
            StartCoroutine("MoveVerticalCoroutine", input);
        }

        protected virtual void MoveHorizontal(Vector2 input)
        {
            Walk(input);
        }

        private void Walk(Vector2 input)
        {
            ChangeSpeed(input);

            // if player character move opposite direction,character reverse

            // Because if player character move opposite direction, 
            // charactor scale vector face the opposite runVel.
            // so, the value of Dot(scale,runVel) = -1
            // Conclusion, When you check the value of Dot(scale, runVel),
            // you can judge whether player charactor have to reverse.

            scale.x = (Vector3.Dot(scale, runVel) >= 0) ? scale.x : scale.x * (-1);
            transform.localScale = scale;
            transform.position = transform.position + runVel * Time.deltaTime;
        }

        private void IncreaseRunSpeed(Vector3 direction)
        {
            if (Vector3.Dot(runVel, direction) < 0)
            {
                runVel = Vector3.zero;
            }
            runVel = runVel + direction * ((runMaxSpeed / reachMaxSpeedTime) * Time.deltaTime);
            runVel = (runVel.magnitude < runMaxSpeed) ? runVel : runMaxSpeed * direction;
        }
        private void DecreaseRunSpeed()
        {
            float velSize = -(runMaxSpeed * Time.deltaTime) / reachRunStopTime + runVel.magnitude;
            runVel = (velSize > 0) ? velSize * runVel.normalized : Vector3.zero;
        }

        private void ChangeSpeed(Vector2 input)
        {

            if (input == Vector2.zero)
            {
                DecreaseRunSpeed();
                return;
            }
            IncreaseRunSpeed(input);
        }
        private void Jump(Vector2 input)
        {
            if (input == Vector2.up)
            {

                if (!coreData.isGround)
                {
                    return;
                }
                if (coreData.speed != 0)
                {
                    rig.velocity = new Vector3(0.5f * runVel.x, 0, 0);
                }
                this.rig.AddForce(transform.up * jumpForce);
                //jason
                JumpEvent.Post(gameObject);
            }
        }

        private IEnumerator StadiumLastAnimationMove()
        {
            for (int i = 0; i < 47; i++)
            {
                transform.position = transform.position + new Vector3(0.1f, 0, 0);
                yield return null;
            }
            for (int i = 0; i < 43; i++)
            {
                yield return null;
            }
            jumpForce = 700;
            Jump(Vector2.up);
            for (int i = 0; i < 90; i++)
            {
                transform.position = transform.position + new Vector3(0.4f, 0, 0);
                yield return null;
            }
        }
        private IEnumerator MoveVerticalCoroutine(Vector2 input)
        {
            var jumpCoroutine = StartCoroutine("JumpCoroutine", input);
            yield return jumpCoroutine;
        }
        private IEnumerator JumpCoroutine(Vector2 input)
        {
            Jump(input);
            yield return new WaitForSeconds(0.1f);
        }
        private bool PossibleToMove() { return coreData.state == PlayerState.Move; }
    }

}