using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
