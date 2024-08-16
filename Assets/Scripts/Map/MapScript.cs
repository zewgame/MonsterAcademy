using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapScript : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    void Start()
    {
        CameraFollow cameraFollow = CameraFollow.instance;
        cameraFollow.setTileMap(tilemap);
    }

   
}
