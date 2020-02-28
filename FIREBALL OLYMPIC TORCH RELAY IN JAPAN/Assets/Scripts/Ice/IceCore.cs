using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;
using Player;
namespace Ice
{
    public class IceCore : MonoBehaviour, IFireSever
    {
        [SerializeField] private GameObject[] wallsGameObject;
        public AK.Wwise.Event MeltEvent;
        public bool isMelting { get; protected set; }
        void Start()
        {
            isMelting = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TouchFire(FireCore fire)
        {
            if (isMelting)
            {
                return;
            }
            
            isMelting = true;
        }
        public bool HasWall()
        {
            return wallsGameObject[0] != null;
        }

        public void DestroyWall()
        {
            foreach (GameObject wall in wallsGameObject)
            {
                Destroy(wall);
            }
        }

        public void MeltSound()
        {
            MeltEvent.Post(gameObject);
        }


    }
}
