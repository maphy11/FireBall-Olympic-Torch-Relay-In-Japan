using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InputSystem
{
    public enum Platform
    {
        PC,
        TabletSmartphone
    };
    public class InputPlatformChanger : MonoBehaviour
    {
        [SerializeField] private Platform platform;
        // public IinputObserver inputObserver { get; private set; }
        // Start is called before the first frame update
        void Start()
        {
            if (platform == Platform.PC)
            {
                gameObject.AddComponent<InputKeyboard>();
            }
            else if (platform == Platform.TabletSmartphone)
            {
                gameObject.AddComponent<InputTouchPanel>();
            }
        }
    }
}

