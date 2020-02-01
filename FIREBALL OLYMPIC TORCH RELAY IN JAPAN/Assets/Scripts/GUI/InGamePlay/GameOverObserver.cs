using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GUI
{
    public class GameOverObserver : MonoBehaviour
    {
        [SerializeField] private PlayerCore coreData;
        [SerializeField] private GameObject GameOverView;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (coreData.isGameOver && !GameOverView.active)
            {
                GameOverView.SetActive(true);
            }
        }
    }
}
