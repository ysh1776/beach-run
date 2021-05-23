using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class StartDirector : MonoBehaviour
{
    GameObject startbtn;

    // Start is called before the first frame update
    void Start()
    {
        this.startbtn = GameObject.Find("StartBtn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clickbtn()
    {
        SceneManager.LoadScene("GameScene");
    }
}
