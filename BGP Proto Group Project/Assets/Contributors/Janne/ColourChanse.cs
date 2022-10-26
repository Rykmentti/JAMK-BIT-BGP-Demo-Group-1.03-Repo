using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanse : MonoBehaviour
{
    private float colorChanse;
    public List<SpriteRenderer> colorChanseTargets;
    void Start()
    {
        SpriteRenderer spriteRenderer;
        HealthSystem health = GetComponent<HealthSystem>();
        colorChanse = health.GetHealth() / health.GetMaxHealt();
        foreach (var target in colorChanseTargets)
        {
            spriteRenderer = target.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color( spriteRenderer.color.r + colorChanse,spriteRenderer.color.g - colorChanse / 1.2f,spriteRenderer.color.b );
            
        }
    }
}
