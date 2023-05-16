  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateCanvasOnClick : MonoBehaviour
{
    public GameObject canvasPrefab;
    void Start()
    {
        //按下按鈕時，呼叫ClickEvent()
        GetComponent<Button>().onClick.AddListener(delegate () {
            ClickEvent();
        });
    }
    void ClickEvent() {
        Instantiate(canvasPrefab,Vector2.zero,Quaternion.identity);
    }
    void Update()
    {
    }
}
