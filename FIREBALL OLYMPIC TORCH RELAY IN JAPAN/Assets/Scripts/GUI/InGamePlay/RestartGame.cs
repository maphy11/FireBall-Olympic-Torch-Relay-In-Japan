using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public AK.Wwise.Event UIRestartEvent;
    // Start is called before the first frame update
    public void OnClick()
    {
        UIRestartEvent.Post(gameObject);
        Application.LoadLevel(SceneManager.GetActiveScene().name);
    }
}
