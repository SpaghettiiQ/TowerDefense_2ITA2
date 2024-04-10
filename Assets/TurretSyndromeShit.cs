using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSyndromeShit : MonoBehaviour
{
    public GameObject TuretuvSynd;
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition) + new Vector3(0,0,9f);
        if(Input.GetMouseButtonDown(1)){ // Kdyz mys ziska Downuv syndrom tak se to stane
            Instantiate(TuretuvSynd, worldPosition, Quaternion.identity);
        }
    }
}
