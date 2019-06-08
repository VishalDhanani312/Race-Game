using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public float carSpeed;
    private Vector3 pos;
    public UiManger ui;
    public AudioManager am;
    bool currentPlatformAndroid = false;
    Rigidbody2D rb;
    bool left = false;
    bool gameOver = false;


    void Awake()
    {
#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif


    }

    // Use this for initialization
	void Start () {
      

        am.carSound.Play();
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (currentPlatformAndroid)
        {


            // TouchMove();
            AccMove();

        }
        else
        {

            pos.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, -4.89f, 5.07f);
            transform.position = pos;
        }
	}



    void TouchMove()
    {
        


        if (Input.touchCount > 0   && !gameOver)
        {

            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            if(touch.position.x <middle && touch.phase == TouchPhase.Began)
            {
                
                left = true;
               
            }
            else if(touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                left = false;
               
            }
            else
            {
                if (left)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            
           
        }
        

    }
    void AccMove()
    {
        float x = Input.acceleration.x;

        if (x < -0.1f)
        {
            MoveLeft();
            Debug.Log("hled");
        }
        else if (x > 0.1f)
        {
            MoveRight();
        }
        Debug.Log(x);


    }

    void MoveLeft()
    {
        pos = transform.position;
        pos.x -= carSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -4.83f, 5.04f);
        transform.position = pos;
       
    }
    void MoveRight()
    {
        pos = transform.position;
        pos.x += carSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -4.83f, 5.04f);
        transform.position = pos;


    }

    void SetZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "EnemyCar")
        {
            Destroy(gameObject,2f);
            ui.GameOver();
            am.carSound.Stop();
            gameOver = true;
        }
    }
}
