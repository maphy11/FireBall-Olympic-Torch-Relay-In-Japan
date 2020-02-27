using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ice
{

    [RequireComponent(typeof(Animator))]
    public class IceAnimation : MonoBehaviour
    {
        [SerializeField] private List<IceCore> coreDatas = new List<IceCore>();
        private Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (coreDatas == null)
            {
                return;
            }
            foreach (IceCore coreData in coreDatas)
            {
                if (!coreData.isMelting)
                {
                    continue;
                }
                animator.SetBool("isMelting", coreData.isMelting);
            }
        }
        private void FinishMelt()
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
