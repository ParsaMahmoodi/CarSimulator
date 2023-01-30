using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenShoter : MonoBehaviour
{
    [SerializeField] private Camera camera;
    private int _shotCount;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            StartCoroutine(ScreenShot());
            Debug.Log("Screenshot taken. \n Camera: " + gameObject.name.ToString());
        }
    }

    IEnumerator ScreenShot()
    {
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;

        Texture2D screenshotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, width, height);
        
        screenshotTexture.ReadPixels(rect, 0, 0);
        screenshotTexture.Apply();

        byte[] byteArray = screenshotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "SCREENSHOTS/" + gameObject.name.ToString() + "/Screenshot " + _shotCount, byteArray);
    }
}
