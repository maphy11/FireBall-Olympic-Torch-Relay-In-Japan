using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IPlayerState
    {
        void StateToWait();
        void StateToMove();
        void StateToPause();
        void StateToDead();
    }
}
