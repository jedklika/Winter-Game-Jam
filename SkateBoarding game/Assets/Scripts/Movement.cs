using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public float SkateSpeed = 20f;
    public float PushSpeed = 25f;
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
    static float Score;
    public Transform RespawnPonit;
    bool Wipeout = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        CurrentTime = StartingTime;
        Trick.text = "";
        Replay.text = "";
        Gameover.text = "";
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
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity);
        transform.Translate(0, 0, SkateSpeed * Time.deltaTime);
        if (onGround && Input.GetMouseButton(0))
        {
            transform.Translate(0, 0, PushSpeed * Time.deltaTime);
        }
        if (onGround && Input.GetMouseButton(1))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 400);
            onGround = false;
            onRail = false;
            inAir = true;

        }
        if (onRail && Input.GetMouseButton(1))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 150);
            onRail = false;
            inAir = true;
        }
        if (transform.position.y >= 4.9)
        {
            onGround = false;
            inAir = true;
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
                Replay.text = "Press R To Replay";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        if (inAir && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.D))
        {

            Trick.text = "KickFlip";
            Score = Score + 10;
            SetFinalScore();

        }
        else if (onGround && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.D))
        {
            Wipeout = true;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
            }
        }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.D))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
        if (inAir && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.A))
        {

            Trick.text = "HeelFlip";
            Score = Score + 10;
            SetFinalScore();

        }
        else if (onGround && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.A))
        {
            Wipeout = true;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;
            }
        }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.A))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
            //if (onGround && onRail == false && Input.GetKey(KeyCode.Space))
            {
                //Trick.text = "Manual";
                //transform.Translate(0, 0, MannualSpeed *- Time.deltaTime);
                //Score = Score + 1;
                //SetFinalScore();
            }
            if (inAir && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.W))
            {

                Trick.text = "Impossible";
                Score = Score + 10;
                SetFinalScore();
            }
            else if (onGround && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.W))
            {
                Wipeout = true;
                if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                }
            }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.W))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
        if (inAir && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.A))
            {

                Trick.text = "Melon";
                Score = Score + 10;
                SetFinalScore();
            }
            else if (onGround && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.A))
            {
                Wipeout = true;
                if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                }
            }
            else if (onGround && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.A))
            {
                Wipeout = true;
                if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                }
            }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.A))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
        if (inAir && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.S))
            {

                Trick.text = "TailGrab";
                Score = Score + 10;
                SetFinalScore();
            }
            else if (onGround && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.S))
            {
                Wipeout = true;
                if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                }
            }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.S))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
        if (inAir && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.S))
            {

                Trick.text = "Pop It Shove It";
                Score = Score + 10;
                SetFinalScore();
            }
            else if (onGround && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.S))
            {
                Wipeout = true;
                if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                }
            }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.S))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
        if (inAir && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.D))
            {

                Trick.text = "Indy";
                Score = Score + 10;
                SetFinalScore();

            }
            else if (onGround && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.D))
            {
                Wipeout = true;
                if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                }
            }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.D))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
        if (inAir && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.W))
            {

                Trick.text = "NoseGrab";
                Score = Score + 10;
                SetFinalScore();
            }
            else if (onGround && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.W))
            {
                Wipeout = true;
                if (Wipeout == true)
                {
                    FinalScore.text = "0";
                    Score = 0f;
                }
            }
        else if (onRail && inAir == false && Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.W))
        {
            Wipeout = true;
            Player.transform.position = RespawnPonit.transform.position;
            if (Wipeout == true)
            {
                FinalScore.text = "0";
                Score = 0f;

            }
        }
        if (onRail && Input.GetKey(KeyCode.F))
            {

                Trick.text = "Crooked";
                Score = Score + 5;
                SetFinalScore();
            }
            if (onRail && Input.GetKey(KeyCode.C))
            {

                Trick.text = "Smith";
                Score = Score + 5;
                SetFinalScore();
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

            }
            if (other.gameObject.CompareTag("Wall"))
            {
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