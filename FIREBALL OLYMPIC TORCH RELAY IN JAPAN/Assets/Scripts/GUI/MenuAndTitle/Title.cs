using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI
{
    public class Title : MonoBehaviour
    {
        private SceneChanger sceneChanger;
        // Start is called before the first frame update
        void Start()
        {
            sceneChanger = GameObject.Find("FadeOutAlphaController").GetComponent<SceneChanger>();
            sceneChanger.OnTapChange();
        }

    }
}
