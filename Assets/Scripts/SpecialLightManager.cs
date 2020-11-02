using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;

public class SpecialLightManager : MonoBehaviour
{

    public List<SpecialLight> speciallights = new List<SpecialLight>();
    public SpecialLight activeLight;
    public Light2D playerPointLight;

    private int activeLightposition = -1;

    public void SwitchLight()
    {
        int count = speciallights.Count;
        activeLightposition += 1;

        if (count == 0)
        {
            return;
        }

        if (activeLight == null)
        {
            activeLight = speciallights[0];
            GameManager.ChangeColorTiles(activeLight.colorName);
            playerPointLight.color = activeLight.lightColor;
        }
        else
        {
            int nextIndex = speciallights.IndexOf(activeLight) + 1;
            if (nextIndex >= speciallights.Count)
            {
                nextIndex = 0;
            }
            if (nextIndex == speciallights.IndexOf(activeLight)) {
                return;
            }

            activeLight = speciallights[nextIndex];
            GameManager.ChangeColorTiles(activeLight.colorName);
            playerPointLight.color = activeLight.lightColor;
        }

        
     
    }

    public void UseLight()
    {
       
    }

    public void Add(SpecialLight l)
    {
        speciallights.Add(l);
        if (speciallights.Count == 1)
        {
            SwitchLight();
        }
    }

}
