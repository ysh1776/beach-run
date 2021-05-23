using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerManagerGameScene : MonoBehaviour
{

    public Valve.VR.SteamVR_Input_Sources handType;
    public Valve.VR.SteamVR_Action_Boolean grabAction;
    public Valve.VR.SteamVR_Action_Boolean clickDebug;
    public Valve.VR.SteamVR_Action_Boolean clickMenu;
    public Valve.VR.SteamVR_Action_Boolean ex;

    public Valve.VR.SteamVR_Input_Sources handType2;
    public Valve.VR.SteamVR_Action_Boolean grabAction2;
    public Valve.VR.SteamVR_Action_Boolean clickDebug2;
    public Valve.VR.SteamVR_Action_Boolean clickMenu2;
    public Valve.VR.SteamVR_Action_Vibration vibration2;

    public GameObject LaserPrefab;
    GameObject Odyssey;
    float clickx;
    float clicky;
    int a;
    float b;
    PlayerMotor pm;
    EndDirector sd;
    // Start is called before the first frame update
    void Start()
    {
        this.a = 0;
        this.b = 0;
        this.pm = GameObject.Find("Player").GetComponent<PlayerMotor>();

        Odyssey = GameObject.Find("EndSceneDirector");
        sd = GetComponent<EndDirector>();

        handType = Valve.VR.SteamVR_Input_Sources.RightHand;
        handType2 = Valve.VR.SteamVR_Input_Sources.LeftHand;

        this.pm.moveVector = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        this.pm.moveVector = Vector3.zero;

        if(this.pm.SkullStatus == 0)
        {
            if (this.pm.controller.isGrounded)
            {
                this.pm.verticalVelocity = -0.5f;
            }
            else
            {
                this.pm.verticalVelocity -= this.pm.gravity * Time.deltaTime;
            }

            // 오른쪽 컨트롤러 눌림과 동시에 플레이어 좌표가 2보다 클경우 못움직임
            if (clickMenu.GetChanged(handType) == true && pm.gameObject.transform.position.x >= 2)
                {
                    this.pm.moveVector.x = 4 * -(this.pm.speed);
                    Debug.Log("오 눌림");
                }
            // 그냥 오른쪽만 누를시 이동
            else if(clickMenu.GetChanged(handType) == true)
            {
                this.pm.moveVector.x = 4 * this.pm.speed;
            }
            // 왼쪽 컨트롤러 눌림과 동시에 플레이어 좌표가 2보다 클경우 못움직임
               if (clickMenu.GetChanged(handType2) == true && pm.gameObject.transform.position.x <= -2)
                {
                    this.pm.moveVector.x = -4 * -(this.pm.speed);
                    Debug.Log("왼 눌림");
                }
               // 그냥 왼쪽만 누를시 이동
                else if(clickMenu.GetChanged(handType2) == true)
                {
                     this.pm.moveVector.x = -4 * this.pm.speed;
                }

               //점프부분
            if(ex.GetChanged(handType) == true &&  pm.gameObject.transform.position.y <= 1.2)
            {
                this.a = 1;
                Debug.Log("~~~~~~~");
            }
            else if(this.a==1)
            {
                this.b += 0.5f;
                this.pm.moveVector.y += b;
                Debug.Log(this.pm.moveVector.y);
                if (this.b >= 10.0f)
                {
                    Debug.Log("2222222222222");
                    this.a = 0;
                    this.b = 0.0f;
                }

            }
         /*   else
            { 
                this.pm.moveVector.y =  1;
            }*/

            this.pm.moveVector.z = this.pm.speed;

            this.pm.controller.Move(this.pm.moveVector * Time.deltaTime);
        }

        // 해골 먹을 경우
        else if(this.pm.SkullStatus ==1)
        {
            if (this.pm.controller.isGrounded)
            {
                this.pm.verticalVelocity = -0.5f;
            }
            else
            {
                this.pm.verticalVelocity -= this.pm.gravity * Time.deltaTime;
            }

            // 오른쪽 검사
            if (clickMenu.GetChanged(handType2) == true && pm.gameObject.transform.position.x >= 2)
            {
                this.pm.moveVector.x = 4 * -(this.pm.speed);
                Debug.Log("오 눌림");
            }
            // 그냥 오른쪽만 누를시 이동
            else if (clickMenu.GetChanged(handType2) == true)
            {
                this.pm.moveVector.x = 4 * this.pm.speed;
            }
            // 왼쪽 컨트롤러 눌림과 동시에 플레이어 좌표가 2보다 클경우 못움직임
            if (clickMenu.GetChanged(handType) == true && pm.gameObject.transform.position.x <= -2)
            {
                this.pm.moveVector.x = -4 * -(this.pm.speed);

                Debug.Log("왼 눌림");
            }
            // 그냥 왼쪽만 누를시 이동
            else if (clickMenu.GetChanged(handType) == true)
            {
                this.pm.moveVector.x = -4 * this.pm.speed;
            }
            //점프구현
            if (ex.GetChanged(handType) == true && pm.gameObject.transform.position.y <= 1.2)
            {
                this.a = 1;
                Debug.Log("~~~~~~~");
            }
            else if (this.a == 1)
            {
                this.b += 0.5f;
                this.pm.moveVector.y += b;
                Debug.Log(this.pm.moveVector.y);
                if (this.b >= 10.0f)
                {
                    Debug.Log("2222222222222");
                    this.a = 0;
                    this.b = 0.0f;
                }

            }
            else
            {
                this.pm.moveVector.y = 1;
            }
            this.pm.moveVector.z = this.pm.speed;

            this.pm.controller.Move(this.pm.moveVector * Time.deltaTime);
        }

        if(pm.gameObject.transform.position.y < -3)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("EndScene");
        }
    }
    }
        

