using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour {

    private Camera MainCamera;

    private void Awake()
    {
        MainCamera = Camera.main;
    }
    

    //放大
    public  void ZoomIn()
    {
        MainCamera.DOOrthoSize(14.00f, 0.5f);
    }
    //缩小
    public void ZoomOut()
    {
        MainCamera.DOOrthoSize(19.00f, 0.5f);
    }
}

