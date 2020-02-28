using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapanSoundRationSaver : MonoBehaviour
{
    [SerializeField] private Transform sakuraSide;
    [SerializeField] private Transform stadiumSide;
    [SerializeField] private Transform fox;
    // private AK.Wwise.RTPC TimeOfDayRTPC;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine("co", 60);

    }

    // Update is called once per frame
    void Update()
    {
        // TimeOfDayRTPC.setValue(GetSoundRation());
    }

    public float GetSoundRation()
    {
        Vector3 sakuraToStadium = stadiumSide.position - sakuraSide.position;
        Vector3 sakuraToFox = fox.position - sakuraSide.position;
        if (Vector3.Dot(sakuraToStadium, sakuraToFox) <= 0) { return 0; }
        float ration = sakuraToFox.x / sakuraToStadium.x;
        return (ration < 1) ? ration : 1;
    }
}
