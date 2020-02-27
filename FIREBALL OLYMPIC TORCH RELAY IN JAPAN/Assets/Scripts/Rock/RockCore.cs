using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCore : MonoBehaviour
{
    [SerializeField] private GameObject topColliderObject;
    // [SerializeField] private float topColliderYPosOffset;
    [SerializeField] private Vector3 topColliderPosOffset;
    // Start is called before the first frame update
    void Start()
    {
        // this.transform.Rotate(0, 0, 360 * Random.value);
        // makeTopCollider();
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
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Fountain")
        {
            Rigidbody2D rig = transform.GetComponent<Rigidbody2D>();
            rig.bodyType = RigidbodyType2D.Static;
            makeTopCollider();
        }
    }

    void makeTopCollider()
    {
        GameObject collider = Instantiate(topColliderObject, this.transform.position + topColliderPosOffset, Quaternion.identity);
        collider.transform.parent = this.transform;
        collider.transform.localScale = new Vector3(5, 5, 1);
    }
}
