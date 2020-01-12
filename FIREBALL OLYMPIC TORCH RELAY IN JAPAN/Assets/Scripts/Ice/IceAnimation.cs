using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ice
{

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(IceCore))]
    public class IceAnimation : MonoBehaviour
    {
        private IceCore coreData;
        private Animator animator;
        void Start()
        {
            coreData = GetComponent<IceCore>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            animator.SetBool("isMelting", coreData.isMelting);
        }
    }
}
