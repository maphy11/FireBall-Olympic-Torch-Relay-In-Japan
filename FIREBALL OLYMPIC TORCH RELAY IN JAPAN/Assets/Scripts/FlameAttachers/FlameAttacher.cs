using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fire;

namespace FlameAttachers
{
    public class FlameAttacher : MonoBehaviour, IPlayerFlame, IFirePasser
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool HasFire()
        {
            return (transform.GetChild(0).gameObject != null);
        }

        public void DeleteFireObj()
        {
            GameObject fireObj = transform.GetChild(0).gameObject;
            fireObj.transform.parent = null;
            Destroy(GetComponent<FireCore>());
            Destroy(fireObj);
        }

        public void PassFire(GameObject fire)
        {
            if (transform.GetComponent<FireCore>() == null)
            {
                // Debug.Log("will wear");
                GameObject fireObj = Instantiate(fire, transform.position, transform.rotation);
                fireObj.transform.localScale = new Vector3(fireObj.transform.localScale.x * transform.localScale.x, fireObj.transform.localScale.y * transform.localScale.y, 1);
                fireObj.transform.parent = this.transform;
                this.transform.gameObject.AddComponent<FireCore>();
            }
        }
    }

}