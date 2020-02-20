using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace GUI
{
    public class GameClear : MonoBehaviour, IPlayerGUIImage
    {
        [SerializeField] private GameObject gameClearPanel;

        // Update is called once per frame
        public void ActiveGameClearPanel()
        {
            gameClearPanel.SetActive(true);
            StartCoroutine("OnTap");
        }
        IEnumerator OnTap()
        {
            yield return null;
            gameClearPanel.GetComponent<SceneChanger>().OnTapChange();
        }
    }
}
