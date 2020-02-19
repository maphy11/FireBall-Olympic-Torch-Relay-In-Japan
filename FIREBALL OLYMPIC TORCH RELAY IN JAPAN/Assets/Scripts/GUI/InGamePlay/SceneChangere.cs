using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using InputSystem;

namespace GUI
{
    public class SceneChangere : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private IinputTap input;
        [SerializeField] private string targetSceneName;
        [SerializeField] private float fadeOutSpeed;
        private Image image;
        // Start is called before the first frame update
        void Start()
        {
            input = player.GetComponent(typeof(IinputTap)) as IinputTap;
            image = GetComponent<Image>();
            // StartCoroutine("TapTrigger");
        }
        IEnumerator StartFadeOut()
        {
            while (image.color.a != 1.0f)
            {
                Color temp = image.color;
                temp.a += fadeOutSpeed * Time.deltaTime;
                image.color.a = temp.a;
                yield return null;
            }
        }
        public IEnumerator TapTrigger()
        {
            yield return new WaitUntil(() => input.OnTap());
            LoadScene();
        }
        public void ButtonTrigger()
        {
            LoadScene();
        }

        void LoadScene()
        {
            if (targetSceneName != null)
            {
                StartCoroutine("ToDiffrentScene");
            }
            else
            {
                StartCoroutine("ReloadScene");
            }
        }
        IEnumerator ToDiffrentScene()
        {
            var fadeOut = StartCoroutine("StartFadeOut");
            yield return fadeOut;
            SceneManager.LoadScene(targetSceneName);
        }

        IEnumerator ReloadScene()
        {
            var fadeOut = StartCoroutine("StartFadeOut");
            yield return fadeOut;
            Application.LoadLevel(SceneManager.GetActiveScene().name);
        }
    }

}