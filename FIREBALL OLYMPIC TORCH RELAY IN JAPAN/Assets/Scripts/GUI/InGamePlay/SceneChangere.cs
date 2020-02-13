using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using InputSystem;

namespace GUI
{
    public class SceneChangere : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private IinputTap input;
        [SerializeField] private string targetSceneName;
        // Start is called before the first frame update
        void Start()
        {

            input = player.GetComponent(typeof(IinputTap)) as IinputTap;
            StartCoroutine("DesplayMenuGUI");
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator DesplayMenuGUI()
        {
            yield return new WaitUntil(() => input.OnTap());
            if (targetSceneName != null)
            {
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Application.LoadLevel(SceneManager.GetActiveScene().name);
            }
        }
    }

}