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
        private float elapsedTime;
        [SerializeField] private Color textColorA;
        [SerializeField] private Color textColorB;
        [SerializeField] private float timeCycle;

        // Start is called before the first frame update
        void Start()
        {
            elapsedTime = 0;
            timeCycle = (timeCycle == 0) ? 1 : timeCycle;
            sceneChanger.a += FontSizeChanger;
            sceneChanger.OnTapChange();
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;

            float CompositionRatio = 2 * (Mathf.Sin(2 * Mathf.PI * elapsedTime / timeCycle) + 1);
            float r = textColorA.r * CompositionRatio + textColorB.r * (1 - CompositionRatio);
            float g = textColorA.g * CompositionRatio + textColorB.g * (1 - CompositionRatio);
            float b = textColorA.b * CompositionRatio + textColorB.b * (1 - CompositionRatio);
            text.color = new Color(r, g, b, 1);
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
