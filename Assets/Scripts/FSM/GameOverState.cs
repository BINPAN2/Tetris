using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : FSMState {
    public void Awake()
    {
        stateID = StateID.Gameover;
    }
}
