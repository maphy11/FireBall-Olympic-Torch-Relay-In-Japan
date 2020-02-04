using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class ClosePauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private PlayerCore coreData;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (coreData.isPause && pausePanel.active)
        {
            pausePanel.SetActive(false);
            coreData.isPause = false;
        }
    }
}
