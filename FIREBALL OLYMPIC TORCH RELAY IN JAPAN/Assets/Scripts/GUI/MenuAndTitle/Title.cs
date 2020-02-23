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
        // [SerializeField] private Color textColorB;
        [SerializeField] private float timeCycle;
        [SerializeField] private float alphaMin;

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

            float compositionRatio = ((1 - alphaMin) * Mathf.Cos(2 * Mathf.PI * elapsedTime / timeCycle) + 1 + alphaMin) / 2;
            text.color = new Color(textColorA.r, textColorA.g, textColorA.b, compositionRatio);
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
