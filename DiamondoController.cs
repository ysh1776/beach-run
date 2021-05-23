using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondoController : MonoBehaviour
{
    GameObject player;
    GameDirector scoreset;
    PlayerMotor pm;
    //fenceController fencle;
    //fenceController fencle2;

    public Vector3 dis;
    public float speed =3.0f;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            this.scoreset.score += 1.0f;
            this.scoreset.count += 1.0f;
            //this.pm.ChState = 0;

        }
    }




    // Start is called before the first frame update
    void Start()
    {
        this.scoreset = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.pm = GameObject.Find("Player").GetComponent<PlayerMotor>();


    }

    // Update is called once per frame
    void Update()
    {
        //this.fencle = GameObject.Find("Hurdle01").GetComponent<fenceController>();
        //this.fencle2 = GameObject.Find("Hurdle02").GetComponent<fenceController>();
        if(this.pm.MagStatus == 1)
        {
            this.dis = (this.player.transform.position - this.gameObject.transform.position).normalized;
            this.dis *= this.speed;

            this.gameObject.transform.position += this.dis * Time.deltaTime * 10 ;
            this.gameObject.transform.up = this.dis;

        }


        if (gameObject.transform.position.z < this.player.transform.position.z - 10)
        {
            Destroy(gameObject);
        }
    }


}