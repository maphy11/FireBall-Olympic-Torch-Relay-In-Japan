using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using InputSystem;

namespace GUI
{
    public class GameClear : MonoBehaviour, IPlayerGUIImage
    {
        [SerializeField] private GameObject gameClearPanel;

        // Update is called once per frame
        public void ActiveGameClearPanel()
        {
            gameClearPanel.SetActive(true);
            gameClearPanel.GetComponent<SceneChanger>().OnTapChange();
        }
    }
}
