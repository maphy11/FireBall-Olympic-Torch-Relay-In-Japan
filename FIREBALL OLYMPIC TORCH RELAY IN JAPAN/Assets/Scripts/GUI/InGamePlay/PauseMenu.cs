using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private PlayerCore coreData;
    private IPlayerState state;
    void Start()
    {
        state = coreData.GetComponent(typeof(IPlayerState)) as IPlayerState;
    }
    // Start is called before the first frame update
    public void OnClickOpenButton()
    {
        if (!pausePanel.active)
        {
            state.ToPause();
            pausePanel.SetActive(true);
        }
    }
    public void OnClickCloseButton()
    {
        if (pausePanel.active)
        {
            state.ToMove();
            pausePanel.SetActive(false);
        }
    }
}

