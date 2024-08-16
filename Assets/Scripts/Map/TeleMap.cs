using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleMap : MonoBehaviour
{
    [SerializeField] private int idmaptele;
    [SerializeField] private bool isback;
    [SerializeField] private int typeButton;
    private GameCanvas gameCanvas;
    void Start()
    {
        gameCanvas = GameCanvas.instance;
        // chua co du lieu
        gameCanvas.createButtonNextMap(idmaptele,gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
