using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraScript
{
    [RequireComponent(typeof(Camera))]
    public class CameraMove : MonoBehaviour
    {
        [SerializeField]
        protected Transform player;
        protected Camera attachedCamera;

        [SerializeField] protected Transform startWallPos;
        [SerializeField] protected Transform endWallPos;
        protected Vector3 startCameraPos;
        protected Vector3 endCameraPos;
        void Start()
        {
            attachedCamera = GetComponent<Camera>();
            startCameraPos = startWallPos.position + (getScreenBottomRight() - getScreenTopLeft()) / 2;
            endCameraPos = endWallPos.position - (getScreenBottomRight() - getScreenTopLeft()) / 2;
        }
        void Update()
        {
            if (startCameraPos.x < player.position.x && endCameraPos.x > player.position.x)
            {
                transform.position = new Vector3(player.position.x, 0, transform.position.z);
            }
        }

        private Vector3 getScreenTopLeft()
        {
            //get image top-left
            Vector3 topLeft = attachedCamera.ScreenToWorldPoint(Vector3.zero);
            // flip upside down
            topLeft.Scale(new Vector3(1f, -1f, 1f));
            return topLeft;
        }

        private Vector3 getScreenBottomRight()
        {
            // get image bottom-right
            Vector3 bottomRight = attachedCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
            // flip upside down
            bottomRight.Scale(new Vector3(1f, -1f, 1f));
            return bottomRight;
        }
    }
}
