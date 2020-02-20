using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerRideOn : MonoBehaviour
    {
        AudioSource inFoxSource;
        SpriteRenderer MainSpriteRenderer;
        [SerializeField]
        AudioClip inFoxClip;
        // Start is called before the first frame update
        void Start()
        {
            inFoxSource = GetComponent<AudioSource>();
            MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D col)
        {

            if (col.tag == "fox")
            {
                Sprite foxImg = col.transform.GetComponent<SpriteRenderer>().sprite;
                MainSpriteRenderer.sprite = foxImg;
                Destroy(col.gameObject);
                Destroy(GetComponent<CapsuleCollider2D>());
                transform.gameObject.AddComponent<BoxCollider2D>();
                inFoxSource.clip = inFoxClip;
                inFoxSource.Play();
                gameObject.AddComponent<PlayerAnimation>();
            }
        }
    }
}
