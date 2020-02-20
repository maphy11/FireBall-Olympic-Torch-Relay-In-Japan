using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage
{
    public class BackgroundMoveController : MonoBehaviour
    {
        //Inspecter setting datas
        [SerializeField] Transform target;
        [SerializeField] private float Speedrate;
        //former 1 frame target possition
        private Vector3 formerTargetPos;
        void Start()
        {
            formerTargetPos = target.position;
        }
        void Update()
        {
            Vector3 targetDeltaMove = target.position - formerTargetPos;
            if (targetDeltaMove != Vector3.zero)
            {
                transform.Translate(-targetDeltaMove.x * Speedrate, 0, 0);

                if (transform.position.x < -13.8)
                {
                    transform.position = new Vector3(13.8f, 0, 0);
                }
            }
            formerTargetPos = target.position;
        }
    }
}
