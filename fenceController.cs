using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceController : MonoBehaviour
{
    GameObject player;
    GameObject hitcheck;
    PlayerMotor pm;
    GameDirector lifed;

    public BoxCollider state;

    int cstate = 1;



    // public BoxCollider state;

    // public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        this.hitcheck = GameObject.Find("GameDirector");
        this.player = GameObject.Find("Player");
        this.pm = GameObject.Find("Player").GetComponent<PlayerMotor>();

        this.state = gameObject.GetComponent<BoxCollider>();
        this.lifed = GameObject.Find("GameDirector").GetComponent<GameDirector>();


        //this.state.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.pm.ChState == 1)
        {
            this.state.enabled = true;
        }
        else if (this.pm.ChState == 0)
        {
            this.state.enabled = false;
        }

        Vector3 p1 = transform.position;
        Vector3 p2 = this.player.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 0.6f;

        if (d < r1 + r2)
            Death();
    }
    private void Death()
    {
        Destroy(gameObject);
        this.hitcheck.GetComponent<GameDirector>().isDead = true;
        if(this.pm.starStatus ==0)
        {
            if (this.lifed.lifecount == 3)
                this.lifed.lifecount = 2;
            else if (this.lifed.lifecount == 2)
                this.lifed.lifecount = 1;
            else if (this.lifed.lifecount == 1)
                this.lifed.lifecount = 0;
            this.pm.speed = 5.0f;
            this.lifed.Level = 1;
            this.lifed.scoreToNextLevel = 10;
            this.lifed.count = 0.0f;
        }

    }


    public void change(int abc)
    {
        this.cstate = abc;
    }



}
