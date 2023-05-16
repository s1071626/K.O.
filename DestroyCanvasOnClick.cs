using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCanvasOnClick : MonoBehaviour
{
    public GameObject canvas;
    public void ClickEvent()
    {
        Destroy(canvas);
    }
}
