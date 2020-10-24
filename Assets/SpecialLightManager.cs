using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpecialLightManager : MonoBehaviour
{

    public List<SpecialLight> speciallights = new List<SpecialLight>();
    public SpecialLight activeLight;
    //public SpotLight

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
        }
        //speciallights.IndexOf(activeLight)

        if (activeLightposition >=  count)
        {
            activeLightposition = 0;
        }

        /* if specialLight.obtained 
          
         */
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
