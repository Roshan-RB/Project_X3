using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    MeshRenderer[] renderers; // Renamed from 'renderer' to 'renderers'


    public void SetTransparency(float _value)
    {
        if (renderers == null)
            renderers = obj.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            Color col = renderers[i].sharedMaterial.color;
            col.a = _value;
            renderers[i].sharedMaterial.color = col;
        }
    }
}
