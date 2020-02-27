using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using InputSystem;
public class PlayerSencerWithHowToPlay : MonoBehaviour
{
    [SerializeField] GameObject howToPlayPanel;
    [SerializeField] GameObject inputManager;
    private IinputTap input;
    private bool isDesplayed;
    public AK.Wwise.Event HowToPlayEvent;
    public AK.Wwise.Event ReturnEvent;
    // Start is called before the first frame update
    void Start()
    {
        input = inputManager.GetComponent(typeof(IinputTap)) as IinputTap;
        isDesplayed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (isDesplayed)
        {
            return;
        }
        IPlayerState state = hit.GetComponent(typeof(IPlayerState)) as IPlayerState;
        if (state != null)
        {
            state.ToPause();
            howToPlayPanel.SetActive(true);
            // the sound process when panel open
            HowToPlayEvent.Post(gameObject);
            StartCoroutine("TapCoroutine", state);
        }
    }
    public IEnumerator TapCoroutine(IPlayerState state)
    {
        yield return new WaitForSeconds(2);
        yield return new WaitUntil(() => input.OnTap());
        // The sound process when panel close.
        ReturnEvent.Post(gameObject);
        howToPlayPanel.SetActive(false);
        state.ToMove();
        isDesplayed = true;
    }
}
