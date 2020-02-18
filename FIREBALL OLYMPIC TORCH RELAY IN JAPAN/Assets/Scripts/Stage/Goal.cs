using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Stage
{
    public class Goal : MonoBehaviour
    {
        [SerializeField] private GameObject touchFire;
        public AK.Wwise.Event GoalEvent;
        // Start is called before the first frame update
        void Start()
        {
            if (touchFire.active)
            {
                touchFire.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D col)
        {
            IPlayerState playerState = col.transform.GetComponent(typeof(IPlayerState)) as IPlayerState;
            if (playerState == null)
            {
                return;
            }
            GoalEvent.Post(gameObject);
            touchFire.SetActive(true);
            playerState.ToGameClear();
            // if you want to implement sound, write down under this comment
        }
    }
}
