using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;
using Player;
namespace Ice
{
    public class IceCore : MonoBehaviour, IFireSever
    {
        public AK.Wwise.Event MeltEvent;
        public bool isMelting { get; protected set; }
        void Start()
        {
            isMelting = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TouchFire(FireCore fire)
        {
            MeltEvent.Post(gameObject);
            isMelting = true;
        }
    }
}
