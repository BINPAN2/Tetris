using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Ctrl ctrl;

    private bool Ispause = true;//是否暂停

    private Shape currentShape = null;

    public Shape[] shapes;

    public Color[] colors;

    private void Awake()
    {
        ctrl = GetComponent<Ctrl>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Ispause) return;
        if (currentShape ==null)
        {
            SpwanShape();
        }
	}

    public void StartGame()
    {
        Ispause = false;
        if (currentShape != null)
        {
            currentShape.Resume();
        }
    }

    public void PauseGame()
    {
        Ispause = true;
        if (currentShape!=null)
        {
            currentShape.Pause();
        }
    }


    public void SpwanShape()
    {
        int indexShape = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);
        currentShape = GameObject.Instantiate(shapes[indexShape]);
        currentShape.Init(colors[indexColor], ctrl,this);
    }

    public void FallDown()
    {
        currentShape = null;
        if (ctrl.Model.isDataUpdate)
        {
            ctrl.View.UpdateGameUI(ctrl.Model.Score, ctrl.Model.Highscore);
        }
        if (ctrl.Model.IsGameOver())
        {
            PauseGame();
            ctrl.View.ShowGameOverUI(ctrl.Model.Score);
        }
    }

    public void ClearShape()
    {
        if (currentShape !=null)
        {
            Destroy(currentShape.gameObject);
            currentShape = null;
        }
    }
}
