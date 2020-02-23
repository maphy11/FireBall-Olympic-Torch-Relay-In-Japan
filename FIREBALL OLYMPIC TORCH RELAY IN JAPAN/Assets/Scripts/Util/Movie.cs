using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using GUI;

public class Movie : MonoBehaviour
{

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private SceneChanger sceneChanger;

    void OnEnable()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void OnDisable()
    {
        videoPlayer.loopPointReached -= EndReached;
    }
    void EndReached(VideoPlayer vp)
    {
        sceneChanger.LoadScene();
    }
}