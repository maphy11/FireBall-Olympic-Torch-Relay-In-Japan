using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            Debug.Log("Ok");
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
