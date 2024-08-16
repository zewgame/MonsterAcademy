using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectList : MonoBehaviour
{
    public static GameObjectList instance;


    [Header("Prefab Button Next Map")]
    public GameObject pf_buttonNextMap;
    private void Awake()
    {
        instance = this;
    }

    public GameObject getButtonNextMap()
    {
        return pf_buttonNextMap;
    }
}
