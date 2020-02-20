using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public interface IPlayerState
    {
        void ToWait();
        void ToMove();
        void ToPause();
        void ToDead();
        void ToGameClear();
        void ToReachStadium();
    }
    interface IPlayerGUIImage
    {
        void ActiveGameClearPanel();
    }
}
