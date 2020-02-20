using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage
{
    [RequireComponent(typeof(Collider2D))]
    public class FloorColliderAdjust : MonoBehaviour
    {
        //Inspecter setting datas
        [SerializeField] private Transform startWall;
        [SerializeField] private Transform endWall;
        private Vector2 colliderScale;
        private Collider2D collider;

        void Start()
        {
            //normlize transform data because this code assume normlize data
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.identity;
            transform.localScale = new Vector3(1, 1, 1);

            collider = GetComponent<Collider2D>();
            //normlize collider Xsize and offset because this code assume normlize data
            colliderScale = new Vector2(1, collider.bounds.size.y);

            float toStartWall = transform.position.x - startWall.position.x - 0.5f;
            float toEndWall = endWall.position.x - transform.position.x + 0.5f;
            colliderScale.x = (toStartWall + toEndWall + 1) * colliderScale.x;

            transform.localScale = colliderScale;

            transform.position = new Vector3((startWall.position.x + endWall.position.x) / 2, transform.position.y, transform.position.z);
        }
    }

}