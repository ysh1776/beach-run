using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public float score = 0.0f;
    public float count = 0.0f;
    public float timec = 0.0f;
    public GameObject timeUI;
    public GameObject scoreUI;
    PlayerMotor pm;


    public  int lifecount=3;
   
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject Skull;
    public GameObject Levelupimg;

    public bool isDead = false;
    public int Level = 1;
    private int MaxLevel = 10;
    public int scoreToNextLevel = 10;
    private GameObject levell;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        
        DontDestroyOnLoad(gameObject);
        this.timeUI = GameObject.Find("Timer");
        this.scoreUI = GameObject.Find("Score");
        this.levell = GameObject.Find("Player");

        this.heart1 = GameObject.Find("Heart1");
        this.heart2 = GameObject.Find("Heart2");
        this.heart3 = GameObject.Find("Heart3");
        this.Skull = GameObject.Find("Skull");
        this.Levelupimg = GameObject.Find("LevelUp");
        this.pm = GameObject.Find("Player").GetComponent<PlayerMotor>();
        this.Skull.SetActive(false);
        this.Levelupimg.SetActive(false);
        GetComponent<AudioSource>().Play();


        this.score = 0.0f;
        this.count = 0.0f;
        this.timec = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        this.heart1.transform.Rotate(0, 3, 0);
        this.heart2.transform.Rotate(0, 3, 0);
        this.heart3.transform.Rotate(0, 3, 0);

        this.timec += Time.deltaTime;
        this.timeUI.GetComponent<Text>().text = "Time : " + this.timec.ToString("F2");
        if (this.isDead)
        {
            this.isDead = false;
            return;
        }
           

        if(this.count >= scoreToNextLevel)
        {
            LevelUp();
            upui();
            Invoke("endupui", 1);
        }


        
        this.scoreUI.GetComponent<Text>().text = "Score : " + ((int)this.score).ToString("F2");
        checkDlife();
        checkSkull();

    }
    void checkSkull()
    {
        if (this.pm.SkullStatus == 0)
            this.Skull.SetActive(false);
        else
            this.Skull.SetActive(true);
    }


    void LevelUp()
    {
        if (this.Level == this.MaxLevel)
            return;

        this.scoreToNextLevel *= 2;
        this.Level++;

        levell.GetComponent<PlayerMotor>().SetSpeed(this.Level/2);


    }

    void upui()
    {
        this.Levelupimg.SetActive(true);
    }
    void endupui()
    {
        this.Levelupimg.SetActive(false);
    }

    void checkDlife()
    {
        if(this.lifecount ==0)
        {
            this.heart1.SetActive(false);
            this.heart2.SetActive(false);
            this.heart3.SetActive(false);
            Time.timeScale = 0;
            GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("EndScene");

        }
        else if(this.lifecount ==1)
        {
            this.heart1.SetActive(true);
            this.heart2.SetActive(false);
            this.heart3.SetActive(false);
        }
        else if(this.lifecount ==2)
        {
            this.heart1.SetActive(true);
            this.heart2.SetActive(true);
            this.heart3.SetActive(false);
        }
        else if (this.lifecount == 3)
        {
            this.heart1.SetActive(true);
            this.heart2.SetActive(true);
            this.heart3.SetActive(true);
        }

    }


}
