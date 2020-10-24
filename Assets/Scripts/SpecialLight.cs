using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Special Light")]
public class SpecialLight : ScriptableObject
{
    public string colorName;
    public int charges;
    public int cooldown;

    public GameObject porjectile;
    
    public void Use()
    {

    }
}
