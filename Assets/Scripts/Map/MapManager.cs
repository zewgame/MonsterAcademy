using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public GameObject[] listMap;
    void Start()
    {
        listMap = Resources.LoadAll<GameObject>("TileMaps");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
