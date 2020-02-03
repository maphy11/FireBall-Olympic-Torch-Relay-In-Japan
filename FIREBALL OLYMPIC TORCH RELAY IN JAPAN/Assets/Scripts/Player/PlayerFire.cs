using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireHolders;

namespace Player
{
    public class PlayerFire : MonoBehaviour
    {
        IPlayerFlame flameAttacher;
        PlayerCore coreData;
        // Start is called before the first frame update
        void Start()
        {
            coreData = GetComponent<PlayerCore>();
            flameAttacher = GetComponent(typeof(IPlayerFlame)) as IPlayerFlame;
        }

        // Update is called once per frame
        void Update()
        {
            if (!flameAttacher.HasFire())
            {
                coreData.isDead = true;
            }
        }
    }
}
