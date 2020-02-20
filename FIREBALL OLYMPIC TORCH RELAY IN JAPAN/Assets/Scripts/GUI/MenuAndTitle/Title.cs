using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class Title : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private SceneChanger sceneChanger;

        // Start is called before the first frame update
        void Start()
        {
            sceneChanger.a += FontSizeChanger;
            sceneChanger.OnTapChange();
        }

        private void FontSmaller()
        {
            int fontSize = text.fontSize;
            fontSize--;
            text.fontSize = fontSize;
        }
        private void FontBigger()
        {
            int fontSize = text.fontSize;
            fontSize++;
            text.fontSize = fontSize;
        }

        private void FontSizeChanger()
        {
            StartCoroutine("FontSizeChangerCoroutine");
        }

        private IEnumerator FontSizeChangerCoroutine()
        {
            while (text.fontSize > 30)
            {
                FontSmaller();
                yield return null;
            }

            while (text.fontSize < 40)
            {
                FontBigger();
                yield return null;
            }
        }

        
    }
}
