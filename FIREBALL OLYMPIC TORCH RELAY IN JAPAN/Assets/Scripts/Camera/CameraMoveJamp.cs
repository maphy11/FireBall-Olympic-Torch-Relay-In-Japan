using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraScript
{
    public class CameraMoveJamp : CameraMove
    {
        protected float initCameraPosY;
        void Start()
        {
            initCameraPosY = 0;
        }
        void Update()
        {
            // float playerPosX = player.position.x;
            transform.position = new Vector3(player.position.x, player.position.y - initCameraPosY, transform.position.z);
        }
    }
}
