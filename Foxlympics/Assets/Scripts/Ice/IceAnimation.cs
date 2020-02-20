using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ice
{

    [RequireComponent(typeof(Animator))]
    public class IceAnimation : MonoBehaviour
    {
        private List<IceCore> coreDatas = new List<IceCore>();
        private Animator animator;
        void Start()
        {
            IceCore parentCoreData = transform.parent.gameObject.GetComponent<IceCore>();
            IceCore selfCoreData = GetComponent<IceCore>();
            if (parentCoreData != null)
            {
                coreDatas.Add(parentCoreData);
            }
            if (selfCoreData != null)
            {
                coreDatas.Add(selfCoreData);
            }
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
