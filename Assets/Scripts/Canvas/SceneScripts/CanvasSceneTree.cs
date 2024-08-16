using UnityEngine.SceneManagement;
using UnityEngine;

public class CanvasSceneTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextSceneTrainLevel()
    {
        SceneManager.LoadScene(1);
    }    
}
