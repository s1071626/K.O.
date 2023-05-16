using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InitializeSelect : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart;
    void Start()
    {
        this.onStart.Invoke();
    }
    void Update()
    {
        
    }
}
