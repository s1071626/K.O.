using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseList : MonoBehaviour
{
    public GameObject canvasPrefab;
    void SetActive() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            canvasPrefab.SetActive(true);
        }
    }
    void Update()
    {
        SetActive();
    }
}
