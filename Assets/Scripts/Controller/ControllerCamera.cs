using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    private Camera mainCamera;
    private Point borders;
    private int ident;
    private float speedCamera;
    private Vector3 pointMove;
    BorderCamera borderCamera;


    // Update is called once per frame
    void Update()
    {
        SetDirectionMoveCamera();
        MoveCamera();
    }

     void Start()
    {
        ident = 80;
        speedCamera = 5;
        mainCamera = Camera.allCameras[0];
        borders = new Point(Screen.width, Screen.height);
        pointMove = new Vector3();

        borderCamera = new BorderCamera
        { 
            borderCameraLeft = -25,
            borderCameraRight = 25,
            borderCameraTop = 10,
            borderCameraBottom = -20 
        };
    }
    

    private void MoveCamera()
    {
        mainCamera.transform.position += pointMove * speedCamera * Time.deltaTime;
    }

    private void SetDirectionMoveCamera()
    {
        var positionMouse = Input.mousePosition;
        pointMove.x = 0;
        pointMove.z = 0;
       
        if (positionMouse.x < ident)
        {
            if (mainCamera.transform.position.x < borderCamera.borderCameraLeft) return;

            var coef = 1 - positionMouse.x / ident;
            pointMove.x = -Mathf.Lerp(0, speedCamera, coef);
        } 
        else if (positionMouse.x > borders.X - ident)
        {
            if (mainCamera.transform.position.x > borderCamera.borderCameraRight) return;

            var delta = borders.X - positionMouse.x;
            var coef = 1 - delta / ident;
            pointMove.x = Mathf.Lerp(0, speedCamera, coef);
        }

        //Вниз
        if (positionMouse.y < ident)
        {
            if (mainCamera.transform.position.z < borderCamera.borderCameraBottom) return;

            var coef = 1 - positionMouse.y / ident;
            pointMove.z = -Mathf.Lerp(0, speedCamera, coef);
        }
        else if (positionMouse.y > borders.Y - ident)
        {
            if (mainCamera.transform.position.z > borderCamera.borderCameraTop) return;

            var delta = borders.Y - positionMouse.y;
            var coef = 1 - delta / ident;
            pointMove.z = Mathf.Lerp(0, speedCamera, coef);
        }
    }

    private struct BorderCamera
    {
        public float borderCameraLeft;
        public float borderCameraRight;
        public float borderCameraTop;
        public float borderCameraBottom;
    }

    private void Interpolation(float x1, float x2, float y1, float y2, float x)
    {
        //return 
    }
}
