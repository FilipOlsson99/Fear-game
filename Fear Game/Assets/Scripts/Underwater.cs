using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{

    public float waterHeight;

    public bool isUnderwater;
    private Color Abovewatercolor;
    private Color Underwatercolor;

    // Start is called before the first frame update
    void Start()
    {
        Abovewatercolor = new Color(0.4f, 0.4f, 0.4f, 0.5f);
        Underwatercolor = new Color(0.15f, 0.25f, 0.3f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.y < waterHeight) != isUnderwater)
        {
            isUnderwater = transform.position.y < waterHeight;
            if (isUnderwater) SetUnderwater();
            if (!isUnderwater) SetNormal();
        }
    }

    void SetNormal()
    {
        RenderSettings.fogColor = Abovewatercolor;
        RenderSettings.fogDensity = 0.004f;
    }

    void SetUnderwater()
    {
        RenderSettings.fogColor = Underwatercolor;
        RenderSettings.fogDensity = 0.02f;
    }
}
