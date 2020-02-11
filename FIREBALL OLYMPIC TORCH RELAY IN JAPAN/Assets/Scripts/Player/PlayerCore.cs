using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireHolders;

namespace Player
{
    public enum Platform
    {
        PC,
        TabletSmartphone
    };

    public enum PlayerState
    {
        Wait,
        Move,
        Pause,
        Dead
    };
    public class PlayerCore : MonoBehaviour, IPlayerState
    {

        [SerializeField] private Platform _platform = Platform.TabletSmartphone;
        public Platform platform { get { return _platform; } }
        public PlayerState state { get; private set; }
        private IPlayerFlame flameAttacher;
        public float speed { get; set; }
        public bool isGround { get; set; }
        public bool isGameOver { get { return state == PlayerState.Dead; } }

        void Start()
        {
            speed = 0;
            isGround = true;
            state = PlayerState.Wait;
            flameAttacher = GetComponent(typeof(IPlayerFlame)) as IPlayerFlame;
        }

        void Update()
        {
            if (!flameAttacher.HasFire())
            {
                StateToDead();
            }
        }
        public void StateToWait() { state = PlayerState.Wait; }
        public void StateToMove() { state = PlayerState.Move; }
        public void StateToPause() { state = PlayerState.Pause; }
        public void StateToDead() { state = PlayerState.Dead; }

    }
}