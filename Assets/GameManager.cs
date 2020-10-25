using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;
    public Map map;
    public GameObject menu;

    public GameObject cyanTiles;
    public GameObject yellowTiles;

    private Dictionary<string, GameObject> colorTiles = new Dictionary<string, GameObject>();


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        instance.colorTiles["Cyan"] = cyanTiles;
        instance.colorTiles["Yellow"] = yellowTiles;
    }

    public static void ChangeColorTiles(string color)
    {
        foreach (KeyValuePair<string, GameObject> go in instance.colorTiles) { 
            if (go.Key == color )
            {
                go.Value.SetActive(true);
            }
            else
            {
                go.Value.SetActive(false);
            }
                
       ; }
    }

   
}
