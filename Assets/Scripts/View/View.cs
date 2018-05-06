using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class View : MonoBehaviour {

    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform gameUI;
    private GameObject restartButton;
    private GameObject GameOverUI;

    private Text score;
    private Text highscore;
    private Text gameoverscore;


    private void Awake()
    {
        logoName = transform.Find("Canvas/LogoName") as RectTransform;
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        restartButton = transform.Find("Canvas/MenuUI/RestartButton").gameObject;
        score = transform.Find("Canvas/GameUI/ScoreLabel/Text").GetComponent<Text>();
        highscore = transform.Find("Canvas/GameUI/HighScoreLabel/Text").GetComponent<Text>();
        GameOverUI = transform.Find("Canvas/GameOverUI").gameObject;
        gameoverscore = transform.Find("Canvas/GameOverUI/Image/ScoreLabel").GetComponent<Text>();
    }

    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-108.4f, 0.5f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(66.9f, 0.5f);
    }
    public void HideMenu()
    {
        logoName.DOAnchorPosY(108.45f, 0.5f).OnComplete(delegate { logoName.gameObject.SetActive(false); });
        menuUI.DOAnchorPosY(-66.85f, 0.5f).OnComplete(delegate { menuUI.gameObject.SetActive(false); });
    }
    public void UpdateGameUI(int score, int highscore)
    {
        this.score.text = score.ToString();
        this.highscore.text = highscore.ToString();
    }
    public void ShowGameUI(int score=0,int highscore=0)
    {
        this.score.text = score.ToString();
        this.highscore.text = highscore.ToString();
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-111.58f, 0.5f);
    }

    public void HideGameUI()
    {
        gameUI.DOAnchorPosY(111.58f, 0.5f).OnComplete(delegate { gameUI.gameObject.SetActive(false); });
    }

    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void ShowGameOverUI(int score=0)
    {
        GameOverUI.SetActive(true);
        gameoverscore.text = score.ToString();
    }

    public void HideGameOverUI()
    {
        GameOverUI.SetActive(false);
    }


}
