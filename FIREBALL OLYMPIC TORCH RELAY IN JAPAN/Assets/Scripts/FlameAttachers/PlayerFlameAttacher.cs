using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;
namespace FlameAttachers
{

    public class PlayerFlameAttacher : FlameAttacher
    {
        // Start is called before the first frame update
        void Start()
        {
            GameObject fire = (GameObject)Resources.Load("Prefabs/Fire");
            PassFire(fire);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
