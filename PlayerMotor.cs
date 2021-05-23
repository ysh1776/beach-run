using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public Vector3 moveVector;
    public CharacterController controller;
    public float speed = 5.0f;
    public float verticalVelocity = 0.0f;
    public float gravity = 12.0f;
    public int starStatus = 0;
    public int ChState;                                 //별 안먹으면 1인상태 먹으면 0인상태

    public int MagStatus = 0;
    public int mcState;                                 //자석 안먹으면 1 먹으면 0

    public int SkullStatus = 0;
    public int SkState;
    //--------------------------------------


   
    // Start is called before the first frame update
    void Start()
    {

        moveVector = Vector3.zero;
        controller = GetComponent<CharacterController>();
        this.ChState = 1;
        this.mcState = 1;
        this.SkState = 1;
        GetComponent<ParticleSystem>().Stop();
        //------------------------------------------




    }

    // Update is called once per frame
    void Update()
    {
       // moveVector = Vector3.zero;

       
        
/*
        if (this.SkullStatus == 0)
        {
            if (controller.isGrounded)
            {
                verticalVelocity = -0.5f;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            if(gameObject.transform.position.x >= 2 && Input.GetAxisRaw("Horizontal") >0)
            {
                moveVector.x = Input.GetAxisRaw("Horizontal") * -speed;
            }
            else if(gameObject.transform.position.x <= -2 && Input.GetAxisRaw("Horizontal") == -1)
            {
                moveVector.x = Input.GetAxisRaw("Horizontal") * -speed;
            }
            else
            {
                moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
            }
            Debug.Log(moveVector.x);
            
            moveVector.y = Input.GetAxisRaw("Vertical") * 5;

            moveVector.z = speed;

            controller.Move(moveVector * Time.deltaTime);
        }
        else if(this.SkullStatus == 1)
        {
            if (controller.isGrounded)
            {
                verticalVelocity = -0.5f;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }

            if (gameObject.transform.position.x >= 2 && Input.GetAxisRaw("Horizontal") == -1)
            {
                moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
            }
            else if (gameObject.transform.position.x <= -2 && Input.GetAxisRaw("Horizontal") == 1)
            {
                moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
            }
            else
            {
                moveVector.x = Input.GetAxisRaw("Horizontal") * -speed;
            }


            moveVector.y = Input.GetAxisRaw("Vertical") * 5;

            moveVector.z = speed;

            controller.Move(moveVector * Time.deltaTime);
        }

    */
     


    }
    void Back()
    {
        Debug.Log("무적종료");
        this.starStatus = 0;
        GetComponent<ParticleSystem>().Stop();
        this.ChState = 1;

    }
    public void StartStarBuff()
    {
        this.starStatus = 1;
        GetComponent<ParticleSystem>().Play();
        Invoke("Back", 5);

    }

    void MagnetOff()
    {

        Debug.Log("자석종료");

        this.MagStatus = 0;
        this.mcState = 1;
        
    }
    public void MagnetOn()
    {
        this.MagStatus = 1;


        Invoke("MagnetOff", 5);
    }

    void SkullOff()
    {
        Debug.Log("방향전환종료");
        this.SkullStatus = 0;
        this.SkState = 1;
    }

    public void SkullOn()
    {
        this.SkullStatus = 1;

        Invoke("SkullOff", 3);
    }


    public void SetSpeed(int modifier)
    {
        this.speed += modifier;
    }

    void Jump(){

    }

}
