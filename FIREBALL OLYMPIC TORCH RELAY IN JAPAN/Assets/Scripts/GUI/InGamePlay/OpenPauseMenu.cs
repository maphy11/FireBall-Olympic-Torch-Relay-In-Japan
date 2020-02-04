using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class OpenPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerCore coreData;
    // Start is called before the first frame update
    public void OnClick()
    {
        if (!pauseMenu.active && !coreData.isPause)
        {
            coreData.isPause = true;
            pauseMenu.SetActive(true);
        }
    }
}
