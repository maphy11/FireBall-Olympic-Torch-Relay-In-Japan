using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearManger
{
    private static StageClearManger _stageClearManger = new StageClearManger();
    static public bool clearedGreeceStage { get; private set; }
    static public bool clearedAlaskaStage { get; private set; }
    static public bool clearedAfricaStage { get; private set; }
    static public bool clearedJapanStage { get; private set; }


    private StageClearManger()
    {
        clearedGreeceStage = false;
        clearedAlaskaStage = false;
        clearedAfricaStage = false;
        clearedJapanStage = false;
    }

    public static StageClearManger GetStageClearManager()
    {
        return _stageClearManger;
    }

    public void ToCleared(string stageName)
    {
        if (stageName == "Greece")
        {
            clearedGreeceStage = true;

        }
        if (stageName == "Alaska")
        {
            clearedAlaskaStage = true;
        }
        if (stageName == "Africa")
        {
            clearedAfricaStage = true;
        }
        if (stageName == "Japan")
        {
            clearedJapanStage = true;
        }

    }
}
