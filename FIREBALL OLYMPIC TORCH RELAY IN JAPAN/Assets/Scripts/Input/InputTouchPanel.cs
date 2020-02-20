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
            isTap = (Input.touchCount > 0);
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                isRight = (touch.position.x > (float)Screen.width / 2);
                isLeft = (touch.position.x < (float)Screen.width / 2);
                CheckIsUpAndIsDown(touch);
                return;
            }
            if (Input.touchCount > 1)
            {
                int JumpTouchIndex = -1;
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    CheckIsUpAndIsDown(touch);
                    if (isUp || isDown)
                    {
                        JumpTouchIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (i == JumpTouchIndex) { continue; }
                    Touch touch = Input.GetTouch(i);
                    isRight = (touch.position.x > (float)Screen.width / 2);
                    isLeft = (touch.position.x < (float)Screen.width / 2);
                    if (isRight || isLeft) { break; }
                }
                return;
            }
            isLeft = false;
            isRight = false;
            isUp = false;
            touchStartPos = null;
            touchEndPos = null;
        }

        void CheckIsUpAndIsDown(Touch touch)
        {
            Flick(touch);
            if (touchStartPos != null && touchEndPos != null)
            {
                isUp = ((touchEndPos.Value - touchStartPos.Value).y > Screen.height / 5);
                isDown = ((touchEndPos.Value - touchStartPos.Value).y < -Screen.height / 5);
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
