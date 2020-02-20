using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireEnemy;
namespace Fire
{
    public interface IGetFireExist
    {

    }
    public class FireCore : MonoBehaviour, IExtinguishable
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ExtinguishFire()
        {
            Destroy(this);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            IFireSever sever = col.transform.GetComponent(typeof(IFireSever)) as IFireSever;
            if (sever != null)
            {
                sever.TouchFire(this);
            }


        }
    }
}

