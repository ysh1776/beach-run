using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickstartbtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void clickmainbtn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
