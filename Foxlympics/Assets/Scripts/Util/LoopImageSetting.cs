using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopImageSetting : MonoBehaviour
{
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        float scroll = Mathf.Repeat(Time.time * 0.2f, 1);
        Vector2 offset = new Vector2(scroll, 0);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
