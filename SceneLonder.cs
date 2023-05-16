using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLonder : MonoBehaviour
{
    int 場景編號;
    void Start()
    {
        場景編號 = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
    }
    
    public void chooseRuleScene() {
        SceneManager.LoadScene(1);
    }
    public void RuleScene() {
        SceneManager.LoadScene(2);
    }
    public void loadStratScene() {
        SceneManager.LoadScene(0);
    }
    public void goGameScene() {
        if (SelectRoleP1.RoleCheck == false && SelectRoleP2.RoleCheck == false) {
            SceneManager.LoadScene(3);
            SelectRoleP1.RoleCheck = true;//重新開始後可重新選角
            SelectRoleP2.RoleCheck = true;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
