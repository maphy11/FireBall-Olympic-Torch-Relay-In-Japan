using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBacktoMenu : MonoBehaviour
{
    public AK.Wwise.Event UIBackEvent;
    public void OnClick()
    {
        UIBackEvent.Post(gameObject);
        SceneManager.LoadScene("Menu");
    }
}
