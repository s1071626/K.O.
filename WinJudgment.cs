using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinJudgment : MonoBehaviour
{
    public GameObject P1W;
    public GameObject P2W;
    public GameObject reStart;
    void Start()
    {
    }
    void Update()
    {
        if (RoleInstance.whoP1 == 0)
        {
            if (Player1.HP <= 0)
            {
                P1W.SetActive(true);
                reStart.SetActive(true);
            }
        }
        else
        {
            if (seanPlayer1.HP <= 0)
            {
                P1W.SetActive(true);
                reStart.SetActive(true);
            }
        }
        if (RoleInstance.whoP2 == 0)
        {
            if (Player2.HP <= 0)
            {
                P2W.SetActive(true);
                reStart.SetActive(true);
            }
        }
        else {
            if (seanPlayer2.HP <= 0)
            {
                P2W.SetActive(true);
                reStart.SetActive(true);
            }
        }
    }
}
