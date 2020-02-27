using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ice
{
    public class IcesList : MonoBehaviour
    {
        [SerializeField] List<IceCore> ices = new List<IceCore>();
        // Start is called before the first frame update
        void Start()
        {
            if (ices.Count > 1)
            {
                // here has error
                ices.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));
            }
            ices[ices.Count - 1].DestroyWall();
        }

        // Update is called once per frame
        void Update()
        {

            if (ices.Count == 0) { return; }
            if (ices[ices.Count - 1] != null) { return; }
            ices.RemoveAt(ices.Count - 1);
            if (ices.Count > 0)
            {
                // here has error
                ices[ices.Count - 1].DestroyWall();
            }
        }
    }
}
