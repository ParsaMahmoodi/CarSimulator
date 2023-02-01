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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == objectToDetect)
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
