
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    //Transform Target;

    //public float Smoothing;
    //Vector3 offset;
    void Start()
    {
        //Target = player.transform;
        //offset = transform.position - Target.position;
    }

   
    //void Update()
    //{
    //    Vector3 TargetCamPos = Target.position + (offset/3);
    //    transform.position = Vector3.Lerp(transform.position, TargetCamPos,Smoothing*Time.deltaTime);
    //}
    private void LateUpdate()
    {
        Transform minX, minY, maxX, maxY;
        try
        {
            minX = GameObject.Find("MinX").GetComponent<Transform>();
            minY = GameObject.Find("MinY").GetComponent<Transform>();
            maxX = GameObject.Find("MaxX").GetComponent<Transform>();
            maxY = GameObject.Find("MaxY").GetComponent<Transform>();
            //if (minX != null && minY != null && maxX != null && maxY != null)
            //{
                Vector3 pos = transform.position;
                pos.x = Mathf.Clamp(player.position.x, minX.transform.position.x, maxX.transform.position.x);
                pos.y = Mathf.Clamp(player.position.y, minY.transform.position.y, maxY.transform.position.y);
                transform.position = pos;
            //}
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
        
       
    }
}
