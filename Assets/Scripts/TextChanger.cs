using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    private TMPro.TMP_Text text;
    private float value = -1f;
    public float multiplier = 5f;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (value < 0)
        {
            value += 0.1f * Time.deltaTime * multiplier;
            text.fontSharedMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, value);
        }
        else if (value > 0)
        {
            value = 0;
        }
    }
}