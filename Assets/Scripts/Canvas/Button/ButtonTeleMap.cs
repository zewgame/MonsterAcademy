using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTeleMap : MonoBehaviour
{
    private Map map = null;
    private GameCanvas gameCanvas;
    [SerializeField] Text txtButton;
    public void nextMap()
    {

        if (map != null)
        {
            // updating
        }
    }
    public void setMap(Map mapData)
    {
        map = mapData;
        txtButton.text = map.nameMap;
    }
}
