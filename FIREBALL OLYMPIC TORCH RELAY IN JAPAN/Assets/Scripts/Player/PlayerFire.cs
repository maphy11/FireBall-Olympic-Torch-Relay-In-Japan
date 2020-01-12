using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;

namespace Player
{
    public class PlayerFire : MonoBehaviour
    {
        FireCore fire;
        PlayerCore coreData;
        // Start is called before the first frame update
        void Start()
        {
            coreData = GetComponent<PlayerCore>();
            fire = GetComponent<FireCore>();
        }

        // Update is called once per frame
        void Update()
        {
            if (fire == null)
            {
                coreData.isDead = true;
            }
        }
    }
}
