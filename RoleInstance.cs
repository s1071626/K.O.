using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleInstance : MonoBehaviour
{
    public GameObject[] P1;
    public GameObject[] P2;
    public GameObject[] P1hand;
    public GameObject[] P2hand;
    public GameObject[] P1cold;
    public GameObject[] P2cold;
    public GameObject P1_Position;
    public GameObject P2_Position;
    public static int whoP1;
    public static int whoP2;
    void Start()
    {
        P1[whoP1].transform.position = P1_Position.transform.position;
        P2[whoP2].transform.position = P2_Position.transform.position;
        P1hand[whoP1].SetActive(true);
        P2hand[whoP2].SetActive(true);
        P1cold[whoP1].SetActive(true);
        P1cold[whoP2].SetActive(true);
        for (int i = 0; i < P1.Length; i++)
        {
            if (i != whoP1)
            {
                P1cold[i].SetActive(false);
                P1hand[i].SetActive(false);
                P1[i].SetActive(false);//把未选择的角色设置为隐藏
            }
        }
        for (int i = 0; i < P2.Length; i++)
        {
            if (i != whoP2)
            {
                P2cold[i].SetActive(false);
                P2hand[i].SetActive(false);
                P2[i].SetActive(false);//把未选择的角色设置为隐藏
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
