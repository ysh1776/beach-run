using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndSceneDirector : MonoBehaviour
{

    GameDirector gd;
    GameObject obj;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject scoreUI;
    float endscore=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        this.star1 = GameObject.Find("ScoreStar1");
        this.star2 = GameObject.Find("ScoreStar2");
        this.star3 = GameObject.Find("ScoreStar3");
        this.scoreUI = GameObject.Find("ScoreText");
        this.obj = GameObject.Find("GameDirector");

        this.endscore = gd.score + (gd.timec * 2);
        Destroy(this.obj);
        this.scoreUI.GetComponent<Text>().text = "Score : " + ((int)this.endscore).ToString("F2");


        if(this.endscore <200)
        {
            this.star1.SetActive(true);
            this.star2.SetActive(false);
            this.star3.SetActive(false);
        }
        else if(this.endscore>200 && this.endscore<400)
        {
            this.star1.SetActive(true);
            this.star2.SetActive(false);
            this.star3.SetActive(true);
        }
        else if(this.endscore>400)
        {
            this.star1.SetActive(true);
            this.star2.SetActive(true);
            this.star3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
