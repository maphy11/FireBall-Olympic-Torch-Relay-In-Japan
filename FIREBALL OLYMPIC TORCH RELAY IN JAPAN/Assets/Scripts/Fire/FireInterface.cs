using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fire
{
    interface IFireSever
    {
        void TouchFire();
    }

    interface IFirePasser
    {
        void PassFire(GameObject fire);
    }
}
