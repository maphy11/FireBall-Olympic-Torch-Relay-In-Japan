using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;

namespace Player
{
    public class PlayerMoverBase : MonoBehaviour
    {
        //Inspecter data
        [SerializeField] private float runMaxSpeed = 1.0f;
        [SerializeField] private float reachMaxSpeedTime = 1.0f;
        [SerializeField] private float reachRunStopTime = 1.0f;
        // [SerializeField] private float jampMaxHeight = 5.0f;
        // [SerializeField] private float jampInputReceptionTime = 0.5f;
        [SerializeField] private float jampForce = 1.0f;
        // [SerializeField] private AudioClip jampSound;
        // [SerializeField] private AudioClip walkSound;

        //Component instance
        protected Rigidbody2D rig;
        private AudioSource audio;
        protected IinputObserver inputObserver;
        private PlayerCore coreData;

        // private float jampInputTime = 0;

        // private float jampVel = 0.0f;

        // private float jampingTime = 0.0f;
        private Vector3 runVel;

        private Vector3 scale;
        void Start()
        {
            Setup();
        }
        void FixedUpdate()
        {
            if (!coreData.isGameOver)
            {
                UpdateMethod();
            }

        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Ground")
            {
                if (!coreData.isGround)
                {
                    coreData.isGround = true;
                    coreData.jampTrigger = false;
                    rig.velocity = Vector2.zero;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Ground")
            {
                if (!(coreData.isGround && coreData.isPause))
                {
                    coreData.isGround = true;
                    coreData.jampTrigger = false;
                    rig.velocity = Vector2.zero;
                }
            }
        }
        protected virtual void Setup()
        {
            PlayerCore pc = GetComponent<PlayerCore>();
            if (pc.platform == Platform.PC)
            {
                inputObserver = gameObject.AddComponent<InputKeyboard>();
            }
            else if (pc.platform == Platform.TabletSmartphone)
            {
                inputObserver = gameObject.AddComponent<InputTouchPanel>();
            }
            coreData = GetComponent<PlayerCore>();
            rig = GetComponent<Rigidbody2D>();
            scale = transform.localScale;
            runVel = Vector3.zero;
            audio = GetComponent<AudioSource>();
        }

        protected virtual void UpdateMethod()
        {
            Vector2 inputVirticle = inputObserver.OnMoveVirtical();
            Vector2 inputHorizontal = inputObserver.OnMoveHorizontal();
            MoveHorizontal(inputHorizontal);
            MoveVirticle(inputVirticle);
            coreData.speed = runVel.magnitude;
        }

        protected virtual void MoveVirticle(Vector2 input)
        {
            Jamp(input);
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
            }
            else
            {
                IncreaseRunSpeed(input);
            }
        }
        private void Jamp(Vector2 input)
        {
            if (input == Vector2.up)
            {
                if (coreData.isGround)
                {
                    this.rig.AddForce(transform.up * jampForce);
                    coreData.isGround = false;
                    // audio.clip = jampSound;
                    audio.Play();
                    coreData.jampTrigger = true;
                }
            }
        }

        // protected virtual void Jamp(Vector2 input, float inputTime)
        // {
        //     if (input == Vector2.up)
        //     {
        //         if (coreData.isGround)
        //         {
        //             jampingTime += Time.deltaTime;
        //             float Ypos = transform.position.y + (3 * (jampMaxHeight * Mathf.Pow(inputTime, -3) / jampInputReceptionTime) * Mathf.Pow((jampingTime - inputTime), 3) + rig.gravityScale * 9.8f * jampingTime) * Time.deltaTime;
        //             transform.position = new Vector3(transform.position.x, Ypos, transform.position.z);

        //             if (jampInputTime + Time.deltaTime < jampInputReceptionTime)
        //             {
        //                 jampInputTime = jampInputTime + Time.deltaTime;
        //             }
        //             else
        //             {
        //                 jampInputTime = jampInputReceptionTime;
        //             }
        //         }
        //         else
        //         {
        //             jampingTime = 0;
        //             jampInputTime = 0;
        //         }
        //     }
        // }
    }

}