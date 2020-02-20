using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;

namespace FireHolders
{
    public class FireHolder : MonoBehaviour, IPlayerFlame
    {
        private FireCore fire;
        // Start is called before the first frame update
        void Start()
        {
            fire = GetComponent<FireCore>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool HasFire()
        {
            return (fire != null);
        }
    }

}