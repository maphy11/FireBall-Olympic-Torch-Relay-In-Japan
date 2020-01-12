using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ice
{
    public class IceOnlyMelt : IceCore
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        protected override void meltIce()
        {
            if (transform.localScale.x <= 0 || transform.localScale.y <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
