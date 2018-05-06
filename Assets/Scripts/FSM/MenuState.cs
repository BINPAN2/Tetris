using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState {
    private void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick, StateID.Play);
    }

    public override void DoBeforeEntering()
    {
        ctrl.View.ShowMenu();
        ctrl.cameraManager.ZoomOut();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.View.HideMenu();
    }

    public void OnStartButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.StartButtonClick);
    }

    public void OnRestartButtonClick()
    {
        ctrl.Model.Restart();
        ctrl.gameManager.ClearShape();
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.StartButtonClick);
    }
}
