using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour {
    [HideInInspector]
    public Model Model;
    [HideInInspector]
    public View View;
    [HideInInspector]
    public CameraManager cameraManager;
    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public AudioManager audioManager;

    private FSMSystem fsm;

    private void Awake()
    {
        Model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        View = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        cameraManager = GetComponent<CameraManager>();
        gameManager = GetComponent<GameManager>();
        audioManager = GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start () {
        MakeFSM();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach(FSMState state in states)
        {
            fsm.AddState(state,this);
        }
        FSMState s = GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(s);
    }
}
