using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenShoter : MonoBehaviour
{

    public GameObject objectToDetect;
    public RenderTexture rt;
    public Camera cam;
    
    private int _shotCount;

    private void Start()
    {
        rt = new RenderTexture(Screen.width, Screen.height, 24);
        cam = GetComponent<Camera>();
        cam.targetTexture = rt;

        _shotCount = 0;
    }

    private void Update()
    {
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;
        
        Vector3 strt = transform.position + new Vector3(0f, -6f, 0f);
        Vector3 dir1 = strt.normalized + new Vector3(5f, 0f, 20);
        Vector3 dir2 = strt.normalized + new Vector3(20f, 0f, -20f);
        Vector3 dir3 = strt.normalized + new Vector3(100f, 0f, 20f);
        
        // Debug.DrawRay(strt, dir1);
        // Debug.DrawRay(strt, dir2);
        // Debug.DrawRay(strt, dir3);
        
        if (Physics.Raycast(strt, dir1, out hit1, Mathf.Infinity))
        {
            if (hit1.collider.gameObject == objectToDetect)
            {
                _shotCount++;
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
                byte[] bytes = texture.EncodeToPNG();
                File.WriteAllBytes( Application.dataPath + "SCREENSHOTS/" + gameObject.name.ToString() + "/Screenshot " + _shotCount +".png", bytes);
                Debug.Log("picture taken");
            }
        }
        
        if (Physics.Raycast(strt, dir2, out hit2, Mathf.Infinity))
        {
            if (hit2.collider.gameObject == objectToDetect)
            {
                _shotCount++;
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
                byte[] bytes = texture.EncodeToPNG();
                File.WriteAllBytes( Application.dataPath + "SCREENSHOTS/" + gameObject.name.ToString() + "/Screenshot " + _shotCount +".png", bytes);
                Debug.Log("picture taken");
            }
        }
        
        if (Physics.Raycast(strt, dir3, out hit3, Mathf.Infinity))
        {
            if (hit3.collider.gameObject == objectToDetect)
            {
                _shotCount++;
                Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
                byte[] bytes = texture.EncodeToPNG();
                File.WriteAllBytes( Application.dataPath + "SCREENSHOTS/" + gameObject.name.ToString() + "/Screenshot " + _shotCount +".png", bytes);
                Debug.Log("picture taken");
            }
        }
        
    }
}
