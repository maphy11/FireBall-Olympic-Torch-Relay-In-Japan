using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GUI
{
    public class GameOverObserver : MonoBehaviour
    {
        [SerializeField] private PlayerCore coreData;

        [SerializeField] private GameObject gameOverView;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (coreData.isGameOver && !gameOverView.active)
            {
                gameOverView.SetActive(true);
                StartCoroutine("OnTap");
            }
        }

        IEnumerator OnTap()
        {
            yield return null;
            gameOverView.GetComponent<SceneChanger>().OnTapChange();
        }
    }
}
