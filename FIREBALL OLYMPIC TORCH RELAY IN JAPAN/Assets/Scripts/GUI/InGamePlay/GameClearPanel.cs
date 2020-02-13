using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;

public class GameClearPanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject player;
    private IinputTap input;
    // Start is called before the first frame update
    void Start()
    {

        input = player.GetComponent(typeof(IinputTap)) as IinputTap;
        StartCoroutine("DesplayMenuGUI");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DesplayMenuGUI()
    {
        yield return new WaitUntil(() => input.OnTap());
        menuPanel.SetActive(true);
        this.gameObject.SetActive(false);

    }
}
