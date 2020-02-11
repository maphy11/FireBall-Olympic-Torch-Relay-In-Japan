using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;
using Player;
namespace Ice
{
    public class IceCore : MonoBehaviour, IFireSever
    {
        [SerializeField] protected PlayerCore coreData;
        [SerializeField] private float coolTime;
        protected IPlayerState state;
        static private bool isInCoolTime;
        public bool isMelting { get; protected set; }
        void Start()
        {
            isMelting = false;
            isInCoolTime = false;
            state = coreData.GetComponent(typeof(IPlayerState)) as IPlayerState;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TouchFire(FireCore fire)
        {
            if (!isInCoolTime)
            {
                isMelting = true;
            }
        }

        private void StartMelt()
        {
            state.StateToWait();
            isInCoolTime = true;
        }

        private void FinishMelt()
        {
            StartCoroutine("EnterCoolTime");
            state.StateToMove();

        }

        IEnumerator EnterCoolTime()
        {
            yield return new WaitForSeconds(coolTime);
            isInCoolTime = false;
            Destroy(this.gameObject);
        }
    }
}
