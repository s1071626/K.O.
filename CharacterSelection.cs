using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterP1;
    public GameObject[] characterP2;
    private int index1 = 0;
    private int index2 = 0;

    private GameObject[] charactershowP1;
    private GameObject[] charactershowP2;
    void Start()
    {

        charactershowP1 = new GameObject[characterP1.Length];
        charactershowP2 = new GameObject[characterP2.Length];
        instantiationcharacter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            index1 += 1;

            if (index1 >= characterP1.Length)
            {
                index1 = 0;
            }
            characterchangeP1(index1);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            index1 -= 1;

            if (index1 < 0)
            {
                index1 = characterP1.Length - 1;
            }
            characterchangeP1(index1);
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index2 += 1;

            if (index2 >= characterP2.Length)
            {
                index2 = 0;
            }
            characterchangeP2(index2);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index2 -= 1;

            if (index2 < 0)
            {
                index2 = characterP2.Length - 1;
            }
            characterchangeP2(index2);
        }

    }

    void characterchangeP1(int indexxxx)
    {
        for (int i = 0; i < characterP1.Length; i++)
        {
            if (i == indexxxx)
            {
                //show

                charactershowP1[i].SetActive(true);
            }
            else
                //unvisible
                //charactershowP1[i].SetActive(false);
                charactershowP1[i].active = false;
        }
    }
    void characterchangeP2(int indexxxx)
    {
        for (int i = 0; i < characterP2.Length; i++)
        {
            if (i == indexxxx)
            {
                //show

                charactershowP2[i].SetActive(true);
            }
            else
                //unvisible
                //charactershowP2[i].SetActive(false);
                charactershowP2[i].active = false;


        }

    }
    void instantiationcharacter()
    {
        for (int i = 0; i < characterP1.Length; i++)
        {

            charactershowP1[i] = (GameObject)(Instantiate(characterP1[i], transform.position, transform.rotation));

        }

        characterchangeP1(index1);
    }

}
