using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float SkateSpeed = 100f;
    public float PushSpeed = 500f;
    bool onGround = true;
    public GameObject Player;
    public float rotationSpeed;
    public float Sensitivity = 2f;
    bool inAir;
    bool onRail;
    public float MannualSpeed = 10f;
    bool GameOver = false;
    bool Restart = false;
    float CurrentTime = 0f;
    float StartingTime = 120f;
    public Text Timer;
    public Text FinalScore;
    public Text Trick;
    public Text ScoreProgress;
    public Text Replay;
    public Text Gameover;
    public Text Fail;
    static float Score;
    public Transform RespawnPonit;
    bool Wipeout = false;
    public float angle;
    private Rigidbody rb;
    private Vector3 normalizeDirection;
    Vector3 pos;
    bool inTrick = false;
    float moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
        CurrentTime = StartingTime;
        Trick.text = "";
        Replay.text = "";
        Gameover.text = "";
        Fail.text = "";
        Score = 0;
        if (Score == 0)
        {
            FinalScore.text = "0";
        }
        if(Wipeout == transform)
        {
            Score = 0;
        }
    }
    void SetFinalScore()
    {
        FinalScore.text = "Score: " + Score.ToString();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * 50f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * 50f);
        }
        Fail.text = "";
        moveInput = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(Vector3.up * moveInput * 20 * Time.deltaTime, ForceMode.VelocityChange);
        rb.AddRelativeForce(Vector3.forward * SkateSpeed * Time.deltaTime, ForceMode.Acceleration);
        Vector3 tempvel = rb.velocity;
        tempvel.y = 0;
        tempvel = Vector3.ClampMagnitude(tempvel, SkateSpeed);
        tempvel.y = rb.velocity.y;
        rb.velocity = tempvel;
        if (onGround && Input.GetButton("R2"))
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.AddRelativeTorque(Vector3.up * moveInput * 30 * Time.deltaTime, ForceMode.VelocityChange);
            rb.AddRelativeForce(Vector3.forward * SkateSpeed * Time.deltaTime, ForceMode.Acceleration);
            tempvel.y = 0;
            tempvel = Vector3.ClampMagnitude(tempvel, SkateSpeed);
            tempvel.y = rb.velocity.y;
            rb.velocity = tempvel;
        }
        if(onGround && Input.GetButtonDown("L2"))
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.AddRelativeTorque(Vector3.up * moveInput * 1, ForceMode.VelocityChange);
            rb.AddRelativeForce(Vector3.forward * 0, ForceMode.Acceleration);
            tempvel.y = 0;
            tempvel = Vector3.ClampMagnitude(tempvel, SkateSpeed);
            tempvel.y = rb.velocity.y;
            rb.velocity = tempvel;
        }
        if (onGround && Input.GetButtonDown("R3"))
        {
           rb.AddForce(Vector3.up * 400);
            onGround = false;
            onRail = false;
            inAir = true;

        }
        if (onRail && Input.GetButtonDown("R3"))
        {
            rb.AddForce(Vector3.up * 250);
            onRail = false;
            inAir = true;
        }
        if (transform.position.y >= 4.9)
        {
            onGround = false;
            inAir = true;
        }
        if (Input.GetButtonDown("Share"))
        {
            SceneManager.LoadScene(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1f * Time.deltaTime;
        Timer.text = CurrentTime.ToString("0");
        if (CurrentTime <= 0)
        {
            CurrentTime = 0;
            if (onGround)
            {
                Time.timeScale = 0;
                Gameover.text = "Gameover";
                Replay.text = "Press Share To Replay";
                if (Input.GetButtonDown("Share"))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        if (inAir && Input.GetButton("Circle") && Input.GetButton("L1"))
        {

            Trick.text = "KickFlip";
            Score = Score + 10;
            SetFinalScore();
            inTrick = true; }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }
        if (onGround && Input.GetButton("Circle") && Input.GetButton("L1"))
        {
            Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
                Wipeout = false;
                inTrick = false;
            }
        }
        if (inAir && Input.GetButton("Square") && Input.GetButton("L1"))
        {

            Trick.text = "HeelFlip";
            Score = Score + 10;
            SetFinalScore();
            inTrick = true;
        }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }

        else if (onRail && Input.GetButton("Square") && Input.GetButton("L1"))
        {
            Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
        }
        else if (onGround && Input.GetButton("Square") && Input.GetButton("L1"))
        {
            Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
        }
        //if (onGround && onRail == false && Input.GetKey(KeyCode.Space))
        {
                //Trick.text = "Manual";
                //transform.Translate(0, 0, MannualSpeed *- Time.deltaTime);
                //Score = Score + 1;
                //SetFinalScore();
            }
        if (inAir && Input.GetButton("Triangle") && Input.GetButton("L1"))
        {

            Trick.text = "Impossible";
            Score = Score + 10;
            SetFinalScore();
            inTrick = true;
        }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }
        else if (onGround && Input.GetButton("Triangle") && Input.GetButton("L1"))
        {
            Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
        }
        if (inAir && Input.GetButton("R1") && Input.GetButton("Square"))
            {

                Trick.text = "Melon";
                Score = Score + 10;
                SetFinalScore();
            inTrick = true;
        }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }
        else if (onGround && Input.GetButton("R1") && Input.GetButton("Square"))
            {
                Wipeout = true;
                Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
            }
        if (inAir && Input.GetButton("R1") && Input.GetButton("X"))
            {
                Trick.text = "TailGrab";
                Score = Score + 10;
                SetFinalScore();
            inTrick = true;
        }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }
        else if (onRail && Input.GetButton("R1") && Input.GetButton("X"))
        {
            Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
        }
        else if (onGround && Input.GetButton("R1") && Input.GetButton("X"))
        {
            Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
        }
        if (inAir && Input.GetButton("X") && Input.GetButton("L1"))
            {
            Trick.text = "Pop It Shove It";
                Score = Score + 10;
                SetFinalScore();
            inTrick = true;
        }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }
        else if (onGround && Input.GetButton("X") && Input.GetButton("L1"))
            {
                Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
            }
        if (inAir && Input.GetButton("R1") && Input.GetButton("Circle"))
            {
                Trick.text = "Indy";
                Score = Score + 10;
                SetFinalScore();
            inTrick = true;
        }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }
        else if (onGround && Input.GetButton("R1") && Input.GetButton("Circle"))
            {
                Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                inTrick = false;
                Wipeout = false;
            }
            }

        if (inAir && Input.GetButton("R1") && Input.GetButton("Triangle"))
            {

                Trick.text = "NoseGrab";
                Score = Score + 10;
                SetFinalScore();
            inTrick = true;
        }
        else if (inTrick = false && inAir)
        {
            Wipeout = false;
            inTrick = false;
        }
        else if (onGround && Input.GetButton("R1") && Input.GetButton("Triangle"))
            {
                Wipeout = true;
            Fail.text = "Fail";
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                inTrick = false;
            }
            }
        if (onRail && Input.GetButton("R1"))
            {

                Trick.text = "Crooked";
                Score = Score + 5;
                SetFinalScore();
            inTrick = true;
            }
            if (onRail && Input.GetButton("L1"))
            {

                Trick.text = "Smith";
                Score = Score + 5;
                SetFinalScore();
            inTrick = true;
            }
        }
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {

                onGround = true;
                inAir = false;
                onRail = false;
                Trick.text = "";
            Fail.text = "";

            }
            if (other.gameObject.CompareTag("Wall"))
            {
            Fail.text = "Get Back";
            
            Player.transform.position = RespawnPonit.transform.position;
        }
        }
        void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Rail"))
            {
                onGround = false;
                inAir = false;
                onRail = true;
                Trick.text = "50-50";
                Score = Score + 1;
                SetFinalScore();
            }
        }
    }