using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GUI;


namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private PlayerCore coreData;
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            coreData = GetComponent<PlayerCore>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetFloat("Speed", coreData.speed);
            animator.SetBool("IsGround", coreData.isGround);
            animator.SetBool("IsDead", coreData.state == PlayerState.Dead);
            animator.SetBool("IsGameClear", coreData.state == PlayerState.GameClear);
        }
    }
}