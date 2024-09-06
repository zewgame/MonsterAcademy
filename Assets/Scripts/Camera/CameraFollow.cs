
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{

    public static CameraFollow instance;
    private Tilemap tilemap;
    private Vector3 dragOrigin;
    [SerializeField] Vector2 MapEdgeDistance;
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
        if(checkTileMap())
        {
            panCamera();
        }
    }
    private void LateUpdate()
    {
        if (checkTileMap())
        {
            BoundsInt cellBounds = tilemap.cellBounds;
            float minX = cellBounds.min.x + MapEdgeDistance.x;
            float maxX = cellBounds.max.x - MapEdgeDistance.x;
            float minY = cellBounds.min.y + MapEdgeDistance.y;
            float maxY = cellBounds.max.y - MapEdgeDistance.y;

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, minX, maxX);
            pos.y = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = pos;
            GameCanvas.instance.SetUpPosionBTeleMap();
        }
    }
    private bool checkTileMap()
    {
        if (tilemap != null)
        {
            return true;
        }
        return false;
    }
    public void setTileMap(Tilemap tm)
    {
        tilemap = tm;
    }
    private void panCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            transform.position += difference;
           
        }
    }
}
