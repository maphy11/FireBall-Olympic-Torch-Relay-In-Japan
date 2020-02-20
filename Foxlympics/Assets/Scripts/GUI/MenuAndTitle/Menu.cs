using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button greece;
    [SerializeField] private Button alaska;
    [SerializeField] private Button africa;
    [SerializeField] private Button japan;
    // private StageClearManger stageClearManger;
    // Start is called before the first frame update
    void Start()
    {
        alaska.enabled = false;
        africa.enabled = false;
        japan.enabled = false;
        // stageClearManger = StageClearManger.GetStageClearManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (StageClearManger.clearedGreeceStage)
        {
            alaska.enabled = true;
        }
        if (StageClearManger.clearedAlaskaStage)
        {
            africa.enabled = true;
        }
        if (StageClearManger.clearedAfricaStage)
        {
            japan.enabled = true;
        }
    }


}
