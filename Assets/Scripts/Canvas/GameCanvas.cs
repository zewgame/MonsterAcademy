using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas instance;
    private GameObjectList gameObjectList = GameObjectList.instance;
    [Header("UI Game")]
    [SerializeField] private GameObject UI_Map;
    [SerializeField] private GameObject UI_Action;
    // các biến liên quan tới chuyển map
    private List<GameObject> buttonTeleList = new List<GameObject>();
    private List<GameObject> OPteleMap = new List<GameObject>();
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // thực thi di chuyển nút chuyển map tới đúng vị trí
        //SetUpPosionBTeleMap();
    }
    // Code Liên quan tới chuyển map ---- Chuyển Map -----
    public void createButtonNextMap(int idMap,GameObject optele)
    {
        GameObject clone = Instantiate(gameObjectList.getButtonNextMap(),transform);
        OPteleMap.Add(optele);
        clone.GetComponent<ButtonTeleMap>().setMap(findMapbyID(idMap));
        buttonTeleList.Add(clone);
        SetUpPosionBTeleMap();
    }
    public Map findMapbyID(int idmap)
    {
       return getMap().Find(map => map.idMap == idmap);
    }
    private void SetUpPosionBTeleMap()
    {
        // thực thi di chuyển các nút tới đúng vị trí trong map
        if(OPteleMap.Count > 0)
        {
            foreach (GameObject optele in OPteleMap)
            {
                if(optele != null)
                {
                    int idex = OPteleMap.IndexOf(optele);
                    GameObject btnTele = buttonTeleList[idex];
                    btnTele.transform.position = Camera.main.ScreenToWorldPoint(optele.transform.position);
                }
            }
        }
       
    }   
    private void ResetBTeleMap()
    {
        // thực thi khi chuyển map xoá tất cả các nút chuyển map
        foreach (GameObject btnteleMap in buttonTeleList)
        {
            Destroy(btnteleMap);
        }
        OPteleMap.Clear();
        buttonTeleList.Clear();
    }    
    private List<Map> getMap()
    {
        List<Map> mapList = new List<Map>();
        mapList.Add(new Map(0,"Khu vực an toàn"));
        mapList.Add(new Map(1,"Thành phố 1"));
        mapList.Add(new Map(2, "Thành phố 2"));
        mapList.Add(new Map(3, "Thành phố 3"));
        mapList.Add(new Map(4, "Thành phố 4"));
        mapList.Add(new Map(5, "Cánh đồng hoang 1"));
        mapList.Add(new Map(6, "Rừng nhiệt đới"));
        mapList.Add(new Map(7, "Vách núi lửa"));
        mapList.Add(new Map(8, "Vách núi lửa 2"));
        mapList.Add(new Map(9, "Vách núi lửa 3"));


        return mapList;
    }
    // EndCode Liên quan tới chuyển map ---- Chuyển Map -----
}
