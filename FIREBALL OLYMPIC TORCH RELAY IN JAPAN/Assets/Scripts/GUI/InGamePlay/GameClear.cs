using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GUI
{
    public class GameClear : MonoBehaviour, IPlayerGUIImage
    {
        [SerializeField] private GameObject gameClearPanel;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public void ActiveGameClearPanel()
        {
            gameClearPanel.SetActive(true);
        }
    }
}
