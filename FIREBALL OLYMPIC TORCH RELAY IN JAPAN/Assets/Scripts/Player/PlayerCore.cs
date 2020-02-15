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
        Dead,
        GameClear,
        ReachStadium,
        StadiumJump
    };
    public class PlayerCore : MonoBehaviour, IPlayerState
    {

        [SerializeField] private Platform _platform = Platform.TabletSmartphone;
        [SerializeField] private GameObject guiPanel;
        public Platform platform { get { return _platform; } }
        public PlayerState state { get; private set; }
        private IPlayerFlame flameAttacher;
        private IPlayerGUIImage guiImage;
        public float speed { get; set; }
        public bool isGround { get; set; }
        public bool isGameOver { get; private set; }

        void Start()
        {
            speed = 0;
            isGround = true;
            state = PlayerState.Move;
            flameAttacher = GetComponent(typeof(IPlayerFlame)) as IPlayerFlame;
            guiImage = guiPanel.GetComponent(typeof(IPlayerGUIImage)) as IPlayerGUIImage;
            isGameOver = false;
        }

        void Update()
        {
            if (!flameAttacher.HasFire())
            {
                ToDead();
            }

            if (state == PlayerState.GameClear)
            {
                StartCoroutine("OnGoal");
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "StadiumTrigger")
            {
                ToReachStadium();
            }
            if (col.gameObject.tag == "StadiumJumpTrigger")
            {
                ToStadiumJump();
            }
        }
        private void OnGameOver()
        {
            StartCoroutine("GameOver");
        }
        IEnumerator GameOver()
        {
            yield return new WaitForSeconds(1);
            isGameOver = true;
        }
        IEnumerator OnGoal()
        {
            yield return new WaitForSeconds(1);
            guiImage.ActiveGameClearPanel();
        }
        public void ToWait() { state = PlayerState.Wait; }
        public void ToMove() { state = PlayerState.Move; }
        public void ToPause() { state = PlayerState.Pause; }
        public void ToDead() { state = PlayerState.Dead; }
        public void ToGameClear() { state = PlayerState.GameClear; }
        public void ToReachStadium() { state = PlayerState.ReachStadium; }
        public void ToStadiumJump() { state = PlayerState.StadiumJump; }

    }


}