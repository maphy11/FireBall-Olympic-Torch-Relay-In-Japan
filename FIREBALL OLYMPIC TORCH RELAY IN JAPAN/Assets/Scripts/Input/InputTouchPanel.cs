using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class InputTouchPanel : InputSearcher
    {
        private Vector3? touchStartPos;
        private Vector3? touchEndPos;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isTap = (Input.touchCount > 0))
            {
                Touch touch = Input.GetTouch(0);
                Flick(touch);
                isRight = (touch.position.x > (float)Screen.width / 2);
                isLeft = (touch.position.x < (float)Screen.width / 2);
                if (touchStartPos != null && touchEndPos != null)
                {
                    isUp = ((touchEndPos.Value - touchStartPos.Value).y > Screen.height / 5);
                    isDown = ((touchEndPos.Value - touchStartPos.Value).y < -Screen.height / 5);
                }


            }

            else
            {
                isLeft = false;
                isRight = false;
                // isUp = 0;
                isUp = false;
                touchStartPos = null;
                touchEndPos = null;
            }
        }



        void Flick(Touch touch)
        {
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;

            }

            if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
            }
        }
    }
}
