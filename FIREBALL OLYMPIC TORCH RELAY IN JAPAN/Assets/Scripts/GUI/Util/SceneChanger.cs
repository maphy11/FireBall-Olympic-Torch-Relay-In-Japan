using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using InputSystem;

namespace GUI
{
    public class SceneChanger : MonoBehaviour
    {
        public delegate void OnSceneChangeDelegate();
        [SerializeField] private GameObject inputManager;
        [SerializeField] private GameObject imageObject;
        [SerializeField] private string targetSceneName;
        [SerializeField] private float fadeOutSpeed;
        private IinputTap input;
        private Image image;
        public event OnSceneChangeDelegate delegateMethods;

        // Start is called before the first frame update
        void Start()
        {
            input = inputManager.GetComponent(typeof(IinputTap)) as IinputTap;
            image = imageObject.GetComponent<Image>();
        }
        public void OnTapChange()
        {
            StartCoroutine("TapCoroutine");

        }
        public IEnumerator TapCoroutine()
        {
            yield return new WaitUntil(() => input.OnTap());
            LoadScene();
        }

        void LoadScene()
        {
            // シーンが変わる際の音の実装はこの下に加えてください
            // シーンのリロード(Re-Start)もここです

            if (targetSceneName != null)
            {
                ToDiffrentScene();
            }
            else
            {
                ReloadScene();
            }
        }
        public void ToDiffrentScene()
        {
            StartCoroutine("ToDiffrentSceneCoroutine");
        }
        public void ReloadScene()
        {
            StartCoroutine("ReloadSceneCoroutine");
        }
        IEnumerator ToDiffrentSceneCoroutine()
        {
            var fadeOut = StartCoroutine("StartFadeOut");
            yield return fadeOut;
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(targetSceneName);
        }

        IEnumerator ReloadSceneCoroutine()
        {
            var fadeOut = StartCoroutine("StartFadeOut");
            yield return fadeOut;
            yield return new WaitForSeconds(0.5f);
            Application.LoadLevel(SceneManager.GetActiveScene().name);
        }
        IEnumerator DelegateMethodsCoroutine()
        {
            delegateMethods?.Invoke();
            yield return null;
        }
        IEnumerator StartFadeOut()
        {
            yield return StartCoroutine("DelegateMethodsCoroutine");
            while (image.color.a < 1.0f)
            {
                Color temp = image.color;
                temp.a += fadeOutSpeed * Time.deltaTime;
                image.color = temp;
                yield return null;
            }
        }
    }

}