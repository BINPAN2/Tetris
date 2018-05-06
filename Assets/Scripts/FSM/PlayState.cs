using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : FSMState {
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        ctrl.View.ShowGameUI(ctrl.Model.Score,ctrl.Model.Highscore);
        ctrl.cameraManager.ZoomIn();
        ctrl.gameManager.StartGame();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.View.HideGameUI();
        ctrl.View.ShowRestartButton();
        ctrl.gameManager.PauseGame();
    }

    public void OnPauseButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.PauseButtonClick);
    }

    public void OnRestartButtonClick()
    {
        ctrl.View.HideGameOverUI();
        ctrl.Model.Restart();
        ctrl.gameManager.StartGame();
        ctrl.View.UpdateGameUI(0, ctrl.Model.Highscore);
    }

    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
