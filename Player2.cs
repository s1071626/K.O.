using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    Rigidbody playerRigidbody;
    Animator 控制器;
    BoxCollider 碰撞器;
    [SerializeField] Slider 血量計;
    void Start()
    {
        碰撞器 = GetComponent<BoxCollider>();
        playerRigidbody = GetComponent<Rigidbody>();
        控制器 = GetComponent<Animator>();
        HP = 1000;
        血量計.value = HP;
    }
    public GameObject RolePosition;
    public GameObject Effect_18_TOP_1;
    public GameObject Effect_02_TOP_1;
    public GameObject Effect_28_TOP;
    public GameObject Effect_32_TOP;
    public GameObject Effect_45_TOP_2;
    readonly float Height;
    private float m_speed = 6f;
    readonly float 跳躍速度 = 100f;
    public static int HP;
    private bool 跳控制器 = true;
    private bool 移動控制 = true;
    //Translate移動控制函數

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (跳控制器)
            {
                playerRigidbody.AddForce(new Vector3(0f, 20f, 0f) * 跳躍速度);
                控制器.SetBool("跳", true);
                控制器.SetBool("後走", false);
                控制器.SetBool("跑步", false);
                跳控制器 = false;
            }
        }
    }
    void MoveControlByTranslate()
    {
        if (控制器.GetCurrentAnimatorStateInfo(0).IsName("小招2") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("小招1") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("中招2") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大招") == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                控制器.SetBool("後走", false);
                控制器.SetBool("跑步", true);
                if (移動控制)
                {
                    this.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                控制器.SetBool("跑步", false);
                控制器.SetBool("後走", true);
                if (移動控制)
                {
                    this.transform.Translate(Vector3.forward * -m_speed / 2 * Time.deltaTime);
                }
            }
            else
            {
                控制器.SetBool("後走", false);
                控制器.SetBool("跑步", false);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                控制器.SetBool("蹲", true);
                控制器.SetBool("後走", false);
                控制器.SetBool("跑步", false);
                移動控制 = false;
            }
            else
            {
                控制器.SetBool("蹲", false);
                移動控制 = true;
            }
        }
    }
    void Attack()
    {
        if (跳控制器 == true && 控制器.GetBool("跑步") == false && 控制器.GetBool("後走") == false
            && 控制器.GetCurrentAnimatorStateInfo(0).IsName("蹲") == false) {
            if (Input.GetKeyDown(KeyCode.Keypad1) && SiroYukiSkill1.isStartTime == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("小招2") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("中招2") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大招") == false)
            {
                SiroYukiSkill1.isStartTime = true;
                控制器.SetBool("小招1", true);
                Instantiate(Effect_18_TOP_1, RolePosition.transform.position, RolePosition.transform.rotation);
                HP += 200;
                if (HP > 1000) {
                    HP = 1000;
                }
                血量計.value = HP;
                Destroy(GameObject.Find("Effect_18_TimeField(Clone)"), 2f);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) && SiroYukiSkill2.isStartTime == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("小招1") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("中招2") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大招") == false)
            {
                SiroYukiSkill2.isStartTime = true;
                控制器.SetBool("小招2", true);
                Instantiate(Effect_02_TOP_1, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_06_MassiveSlash(Clone)"), 1.5f);
            }
            /*else if (Input.GetKeyDown(KeyCode.L) && SiroYukiSkillL.isStart == false)
            {
                控制器.SetBool("中招1", true);
                Instantiate(Effect_32_TOP, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_32_DevilEye(Clone)"),4f);
            }*/
            else if (Input.GetKeyDown(KeyCode.Keypad4) && SiroYukiSkill4.isStartTime == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("小招1") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("小招2") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大招") == false)
            {
                SiroYukiSkill4.isStartTime = true;
                控制器.SetBool("中招2", true);
                Instantiate(Effect_45_TOP_2, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_45_BlastFlame(Clone)"), 4f);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5) && SiroYukiSkill5.isStartTime == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("小招1") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("小招2") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("中招2") == false)
            {
                SiroYukiSkill5.isStartTime = true;
                移動控制 = false;
                控制器.SetBool("大招", true);
                Instantiate(Effect_28_TOP, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_28_PurifierBeam(Clone)"), 2f);
            }
            else
            {
                控制器.SetBool("小招1", false);
                控制器.SetBool("小招2", false);
                控制器.SetBool("中招1", false);
                控制器.SetBool("中招2", false);
                控制器.SetBool("大招", false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            控制器.SetBool("跳", false);
            跳控制器 = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sean1")
        {
            HP -= 80;
            Debug.Log(HP);
            血量計.value = HP;
        }
        if (other.gameObject.tag == "sean2")
        {
            HP -= 100;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "sean4")
        {
            HP -= 150;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "sean5")
        {
            HP -= 450;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "Siro2")
        {
            HP -= 70;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "Siro3")
        {
            HP -= 150;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "Siro4")
        {
            HP -= 150;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "Siro5")
        {
            HP -= 250;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "P1sean1")
        {
            HP -= 80;
            Debug.Log(HP);
            血量計.value = HP;
        }
        if (other.gameObject.tag == "P1sean2")
        {
            HP -= 100;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "P1sean4")
        {
            HP -= 150;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "P1sean5")
        {
            HP -= 450;
            血量計.value = HP;
            Debug.Log(HP);
        }
    }
    void Update()
    {
        MoveControlByTranslate();
        Jump();
        Attack();
    }
}
