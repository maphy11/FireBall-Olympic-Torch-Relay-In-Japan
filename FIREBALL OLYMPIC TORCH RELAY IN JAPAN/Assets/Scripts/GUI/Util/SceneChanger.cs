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
        [SerializeField] private GameObject inputManager;
        [SerializeField] private string targetSceneName;
        [SerializeField] private float fadeOutSpeed;
        private IinputTap input;
        private Image image;
        // Start is called before the first frame update
        void Start()
        {
            input = inputManager.GetComponent(typeof(IinputTap)) as IinputTap;
            image = GetComponent<Image>();
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
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(targetSceneName);
        }

        IEnumerator ReloadSceneCoroutine()
        {
            var fadeOut = StartCoroutine("StartFadeOut");
            yield return fadeOut;
            yield return new WaitForSeconds(1);
            Application.LoadLevel(SceneManager.GetActiveScene().name);
        }
        IEnumerator StartFadeOut()
        {
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