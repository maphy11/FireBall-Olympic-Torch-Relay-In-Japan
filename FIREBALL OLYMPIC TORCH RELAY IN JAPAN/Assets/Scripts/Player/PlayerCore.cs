using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum Platform
    {
        PC,
        TabletSmartphone
    };

    [RequireComponent(typeof(PlayerMoverBase))]
    [RequireComponent(typeof(PlayerFire))]
    public class PlayerCore : MonoBehaviour
    {

        [SerializeField] private Platform _platform = Platform.TabletSmartphone;
        public Platform platform { get { return _platform; } }

        public float speed { get; set; }
        public bool isGround { get; set; }
        public bool jampTrigger { get; set; }
        // public bool isDead { get; set; }
        public bool isDead;
        public bool isGameOver { get { return isDead; } }
        void Start()
        {
            speed = 0;
            // fire = GetComponent<PlayerFire>();
            isGround = true;
            jampTrigger = false;
            isDead = false;
        }
    }
}