using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public interface IinputObserver
    {
        Vector2 OnMoveVertical();
        Vector2 OnMoveHorizontal();
    }
    public interface IinputTap
    {
        bool OnTap();
    }
    public class InputSearcher : MonoBehaviour, IinputObserver, IinputTap
    {

        private static InputSearcher mInstance;
        [HideInInspector]
        protected bool isUp { get; set; }
        [HideInInspector]
        protected bool isDown { get; set; }
        [HideInInspector]
        protected bool isLeft { get; set; }
        [HideInInspector]
        protected bool isRight { get; set; }

        protected bool isTap { get; set; }

        public static InputSearcher Instance
        {
            get
            {
                if (mInstance == null)
                {
                    GameObject obj = new GameObject("InputSearcher");
                    mInstance = obj.AddComponent<InputSearcher>();
                }
                return mInstance;
            }
        }

        public Vector2 OnMoveVertical()
        {
            if (isUp)
            {
                return Vector2.up;
            }
            else if (isDown)
            {
                return Vector2.down;
            }
            else
            {
                return Vector2.zero;
            }
        }
        public Vector2 OnMoveHorizontal()
        {
            if (isLeft)
            {
                return Vector2.left;
            }

            else if (isRight)
            {
                return Vector2.right;
            }
            else
            {
                return Vector2.zero;
            }
        }

        public bool OnTap()
        {
            return isTap;
        }

    }
}
