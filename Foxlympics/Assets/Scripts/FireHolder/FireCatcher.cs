using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;

namespace FireHolders
{
    public class FireCatcher : MonoBehaviour, IFireSever
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TouchFire(FireCore fire)
        {
            if (transform.GetComponent<FireCore>() == null)
            {
                Destroy(fire);
                this.transform.gameObject.AddComponent<FireCore>();
            }
        }
    }
}
