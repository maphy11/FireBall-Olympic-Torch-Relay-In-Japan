using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropMaker : MonoBehaviour
{
    [SerializeField] private GameObject waterDrop;
    [SerializeField] private float dropInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MakeWaterDrop");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MakeWaterDrop()
    {
        while (true)
        {
            yield return new WaitForSeconds(dropInterval);
            Instantiate(waterDrop, this.transform.position, this.transform.rotation);
        }
    }
}
