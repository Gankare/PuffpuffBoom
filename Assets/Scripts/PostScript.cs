using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class PostScript : MonoBehaviour
{
    private int i = -15;
    public float vignetteValue;
    public float colorGradingValue;
    private Transform playerPos;
    private float depthCounter;

    private PostProcessVolume volume;
    private Vignette vignette;
    private ColorGrading colorGrading;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        volume = GetComponent<PostProcessVolume>();
        vignette = GetComponent<Vignette>();
        colorGrading = GetComponent<ColorGrading>();
    }

    void Update()
    {
        depthCounter = playerPos.transform.position.y;

        if (i > depthCounter)
        {
            volume.profile.TryGetSettings(out vignette);
            vignette.intensity.value += vignetteValue;
            volume.profile.TryGetSettings(out colorGrading);
            colorGrading.postExposure.value -= colorGradingValue;
            i -= 1;
        }
    }
}
