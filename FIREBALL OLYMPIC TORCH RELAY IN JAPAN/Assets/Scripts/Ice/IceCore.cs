using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;

namespace Ice
{
    public abstract class IceCore : MonoBehaviour, IFireSever
    {

        [SerializeField] protected float needTimeMelting;
        public float meltingTime { get; protected set; }
        public bool isMelting { get; protected set; }
        void Start()
        {
            isMelting = false;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (isMelting)
            {
                meltIce();
            }
        }

        public void TouchFire()
        {
            isMelting = true;
        }

        protected virtual void meltIce() { }
    }
}
