using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    bool isPause;
    public GameObject PauseBut;
    void PauseOnClick()
    {
        isPause = !isPause;
    }
}
