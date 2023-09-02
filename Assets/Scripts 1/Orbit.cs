﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public Transform cam;
    public Vector3 offset = Vector3.zero;
    public float cameraRotSide;
    public float cameraRotUp;
    public float cameraRotSideCur, maxRotUp, minRotUp, maxSideRot = 360, minSideRot = 360;

    public float cameraRotUpCur;
    public float distance;
    public bool reset_pos;
    public float pinchSpeed = 1;
    private Touch touch;
    private float lastDist = 0;
    private float curDist = 0;
    public float initial_dist;
    public float c;
    public float zoomStart = 3.5f;
    public float zoomMin = 0.5f;
    public float zoomMax = 7.5f;
    public float cameraRotSideStart;
    public float cameraRotUpStart;
    public float CurentZoom;
    public bool zoom_In;
    public bool zoom_Out;
    public bool orbit_enabled;
    public bool Zoom_bool;
    public bool pan_bool;

    public float InitiaZoom, InitialRot;
    public bool disableInteration;



    public void Start()
    {

        target = this.transform;
        cam = Camera.main.transform;


        // pinchSpeed = 1f;
        cameraRotSide = cameraRotSideStart;
        cameraRotUp = cameraRotUpStart;
        cameraRotUpCur = transform.localEulerAngles.x;
        cameraRotSideCur = transform.localEulerAngles.y;

        distance = zoomStart;
        reset_pos = false;
        orbit_enabled = true;
        Zoom_bool = true;
        pan_bool = false;
        disableInteration = false;


        InitiaZoom = zoomStart;
        InitialRot = cameraRotUpStart;




    }
    public void DisableInteractionOnUI(bool status)
    {
        disableInteration = status;
    }

    void Update()
    {
        if (disableInteration)
            return;

        if (orbit_enabled)
        {

            reset_pos = false;
            CurentZoom = cam.localPosition.z;

            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {

                if (Input.GetMouseButton(0) && !pan_bool)
                {
                    cameraRotSide += Input.GetAxis("Mouse X") * 2.5f;
                    cameraRotUp -= Input.GetAxis("Mouse Y") * 2.5f;

                }

                if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    cameraRotSide += Input.touches[0].deltaPosition.x;
                    cameraRotUp -= Input.touches[0].deltaPosition.y;

                }

            }
            else
            {


                if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    cameraRotSide += Input.GetAxis("Mouse X") * 1;
                    cameraRotUp -= Input.GetAxis("Mouse Y") * 1;

                }
            }
        }

        if (Zoom_bool)
        {
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {

                //



                if (Input.touchCount > 1 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
                {
                    var touch1 = Input.GetTouch(0);
                    var touch2 = Input.GetTouch(1);
                    curDist = Vector2.Distance(touch1.position, touch2.position);

                    if (curDist > lastDist)
                    {
                        distance -= Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 500;
                    }
                    else
                    {
                        distance += Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 500;
                    }

                    lastDist = curDist;

                }



                distance *= (1 - 1 * Input.GetAxis("Mouse ScrollWheel"));

            }
            else
            {
                if (Input.touchCount > 1 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
                {
                    var touch1 = Input.GetTouch(0);
                    var touch2 = Input.GetTouch(1);
                    curDist = Vector2.Distance(touch1.position, touch2.position);

                    if (curDist > lastDist)
                    {
                        distance -= Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 60;
                    }
                    else
                    {
                        distance += Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 60;
                    }

                    lastDist = curDist;
                }
            }

            if (zoom_In)
            {
                distance -= 0.01f;
            }
            if (zoom_Out)
            {
                distance += 0.01f;
            }
        }

        if (pan_bool)
        {

            if (Application.platform != RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsPlayer)
            {

                if (Input.GetMouseButton(0))
                {

                    float x = -Input.GetAxis("Mouse X") * 0.8f * distance / 30;
                    float y = -Input.GetAxis("Mouse Y") * 0.8f * distance / 30;
                    cam.transform.localPosition = new Vector3(cam.transform.localPosition.x + x, cam.transform.localPosition.y + y, cam.transform.localPosition.z);
                }

                if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    if (Input.GetMouseButton(0))
                    {
                        float x = -Input.touches[0].deltaPosition.x * distance / 500;
                        float y = -Input.touches[0].deltaPosition.y * distance / 500;
                        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x + x, cam.transform.localPosition.y + y, cam.transform.localPosition.z);
                    }
                }

            }
            else
            {
                if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    if (Input.GetMouseButton(0))
                    {
                        float x = -Input.GetAxis("Mouse X") * 0.8f * distance / 60;
                        float y = -Input.GetAxis("Mouse Y") * 0.8f * distance / 60;
                        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x + x, cam.transform.localPosition.y + y, cam.transform.localPosition.z);
                    }
                }
            }
        }

        if (distance <= zoomMin)
        {
            distance = zoomMin;
        }
        else if (distance >= zoomMax)
        {
            distance = zoomMax;
        }

        if (cam.GetComponent<Camera>().orthographicSize <= zoomMin)
        {
            cam.GetComponent<Camera>().orthographicSize = zoomMin;
        }
        else if (cam.GetComponent<Camera>().orthographicSize >= zoomMax)
        {
            cam.GetComponent<Camera>().orthographicSize = zoomMax;
        }


        if (cameraRotSide > 180)
            cameraRotSide = -180;
        if (cameraRotSide < -180)
            cameraRotSide = +180;

        if (cameraRotUp < -minRotUp)
        {
            cameraRotUp = -minRotUp;
        }
        if (cameraRotUp > maxRotUp)
        {
            cameraRotUp = maxRotUp;
        }


        if (cameraRotSide < -minSideRot)
        {
            cameraRotSide = -minSideRot;
        }
        if (cameraRotSide > maxSideRot)
        {
            cameraRotSide = maxSideRot;
        }

        //if (orbit_enabled) {
        cameraRotSideCur = Mathf.LerpAngle(cameraRotSideCur, cameraRotSide, Time.deltaTime * 5);
        cameraRotUpCur = Mathf.Lerp(cameraRotUpCur, cameraRotUp, Time.deltaTime * 5);
        //	}
        Vector3 targetPoint = target.position;
        transform.position = Vector3.Lerp(transform.position, targetPoint + offset, Time.deltaTime);
        transform.rotation = Quaternion.Euler(cameraRotUpCur, cameraRotSideCur, 0);


        float dist = Mathf.Lerp(-cam.transform.localPosition.z, distance, Time.deltaTime * 5);
        cam.localPosition = new Vector3(cam.localPosition.x, cam.localPosition.y, -dist);
        c = -dist;
        //}
    }
}