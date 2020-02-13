﻿using System.Collections;
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
    }
    interface IPlayerGUIImage
    {
        void ActiveGameClearPanel();
    }
}
