using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour{

    private Ctrl ctrl;
    private Transform pivot;
    private GameManager gameManager;

    private bool Ispause = false;

    private bool IsSpeedUp = false;

    private float timer = 0;

    private float steptime = 0.8f;

    private int multiple = 15;

    private void Awake()
    {
        pivot = transform.Find("Pivot");
    }

    private void Update()
    {
        if (Ispause == true) return;
        timer += Time.deltaTime;
        if (timer > steptime)
        {
            timer = 0;
            Fall();
        }
        InputControl();
    }

    public void Init(Color color,Ctrl ctrl,GameManager gameManager)
    {
        foreach (Transform t in transform)
        {
            if (t.tag=="Block")
            {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }

        this.ctrl = ctrl;
        this.gameManager = gameManager;
    }

    public void Fall()
    {
        Vector3 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
        if (ctrl.Model.IsValidMapPosition(this.transform)==false)
        {
            pos.y += 1;
            transform.position = pos;
            Ispause = true;
            bool isclear = ctrl.Model.PlaceShape(this.transform);
            if (isclear)  ctrl.audioManager.PlayClear();
            gameManager.FallDown();
            return;
        }
            ctrl.audioManager.PlayDrop();
    }

    private void InputControl()
    {
        float h = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            h = -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            h = 1;
        }
        if (h != 0)
        {
            Vector3 pos = transform.position;
            pos.x += h;
            transform.position = pos;
            if (ctrl.Model.IsValidMapPosition(this.transform) == false)
            {
                pos.x -= h;
                transform.position = pos;
            }
            else
            {
                ctrl.audioManager.PlayControl();
            }
           
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(pivot.position, Vector3.forward, -90);
            if (ctrl.Model.IsValidMapPosition(this.transform) == false)
            {
                transform.RotateAround(pivot.position, Vector3.forward, 90);
            }
            else
            {
                ctrl.audioManager.PlayControl();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            IsSpeedUp = true;
            steptime /= multiple;
        }
        
    }

    public void Pause()
    {
        Ispause = true;
    }

    public void Resume()
    {
        Ispause = false;
    }


}
