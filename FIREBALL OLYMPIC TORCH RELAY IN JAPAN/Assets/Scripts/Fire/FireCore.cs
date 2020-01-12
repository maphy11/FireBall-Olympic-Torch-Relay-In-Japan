using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireEnemy;

namespace Fire
{

    public class FireCore : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D col)
        {
            IFireSever sever = col.transform.GetComponent(typeof(IFireSever)) as IFireSever;
            if (sever != null)
            {
                sever.TouchFire();
            }

            IExtinguisher extinguisher = col.transform.GetComponent(typeof(IExtinguisher)) as IExtinguisher;
            if (extinguisher != null)
            {
                extinguisher.ExtinguishFire(this);
            }
        }
    }
}

