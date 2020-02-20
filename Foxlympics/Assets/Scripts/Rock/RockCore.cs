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
            Rigidbody2D rig = transform.GetComponent<Rigidbody2D>();
            rig.velocity = Vector2.zero;
            // rig.angularVelocity = 0;

        }
    }
}
