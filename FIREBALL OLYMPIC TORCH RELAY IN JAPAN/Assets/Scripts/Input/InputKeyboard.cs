using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class InputKeyboard : InputSearcher
    {
        // private float elapsedTime = 0;
        void Update()
        {
            isUp = (Input.GetKey(KeyCode.UpArrow));
            isDown = (Input.GetKey(KeyCode.DownArrow));
            isLeft = (Input.GetKey(KeyCode.LeftArrow));
            isRight = (Input.GetKey(KeyCode.RightArrow));
            isTap = (Input.GetMouseButtonDown(0));
        }
        // float Up(bool inputUp)
        // {
        //     elapsedTime = inputUp ? elapsedTime + Time.deltaTime : 0;
        //     return elapsedTime;
        // }

    }

}