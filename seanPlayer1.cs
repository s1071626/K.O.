using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seanPlayer1 : MonoBehaviour
{
    Rigidbody playerRigidbody;
    Animator 控制器;
    [SerializeField] Slider 血量計;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        控制器 = GetComponent<Animator>();
        HP = 1000;
        血量計.value = HP;
    }
    public GameObject RolePosition;
    public GameObject Effect_08_Top;
    public GameObject Effect_07_Top;
    public GameObject Effect_02_Down;
    public GameObject Effect_36_TOP_1;
    public GameObject Effect_21_TOP_1;
    readonly float Height;
    private float m_speed = 6f;
    readonly float 跳躍速度 = 10f;
    public static int HP;
    private bool 跳控制器 = true;
    private bool 移動控制 = true;
    void Update()
    {
        Jump();
        MoveControlByTranslate();
        Attack();
    }
    void Jump()
    {
        if (控制器.GetCurrentAnimatorStateInfo(0).IsName("大絕") == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (跳控制器)
                {
                    playerRigidbody.AddForce(new Vector3(0f, 200f, 0f) * 跳躍速度);
                    控制器.SetBool("跳", true);
                    控制器.SetBool("後走", false);
                    控制器.SetBool("跑步", false);
                    跳控制器 = false;
                }
            }
        }
    }
    void MoveControlByTranslate()
    {
        if (控制器.GetCurrentAnimatorStateInfo(0).IsName("右出拳") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("膝擊") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("踢擊") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("連打") == false)
            if (Input.GetKey(KeyCode.A))
            {
                控制器.SetBool("後走", false);
                控制器.SetBool("跑步", true);
                if (移動控制)
                {
                    this.transform.Translate(Vector3.forward * -m_speed * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                控制器.SetBool("跑步", false);
                控制器.SetBool("後走", true);
                if (移動控制)
                {
                    this.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
                }
            }
            else
            {
                控制器.SetBool("後走", false);
                控制器.SetBool("跑步", false);
            }
        if (Input.GetKey(KeyCode.W))
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
    void Attack()
    {
        if (控制器.GetCurrentAnimatorStateInfo(0).IsName("跳") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("跑步") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("後走") == false)
        {
            if (seanSkillJ.isStartTime ==false && Input.GetKeyDown(KeyCode.J) && 控制器.GetCurrentAnimatorStateInfo(0).IsName("右出拳") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("膝擊") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("踢擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("連打") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大絕") == false)
            {
                seanSkillJ.isStartTime = true;
                控制器.SetBool("右出拳", true);
                Instantiate(Effect_02_Down, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_02_FistHit(Clone)"), 1f);

            }
            else if (Input.GetKeyDown(KeyCode.K) && 控制器.GetCurrentAnimatorStateInfo(0).IsName("膝擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("右出拳") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("踢擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("連打") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大絕") == false
                && seanSkillK.isStartTime == false)
            {
                seanSkillK.isStartTime = true;
                控制器.SetBool("膝擊", true);
                Instantiate(Effect_07_Top, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_07_OneHandSmash(Clone)"), 1f);
            }
            /*else if (Input.GetKeyDown(KeyCode.Keypad3) && 控制器.GetCurrentAnimatorStateInfo(0).IsName("踢擊") == false 
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("右出拳") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("膝擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("連打") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大絕") == false
                && seanSkill3.isStartTime == false)
            {
                控制器.SetBool("踢擊", true);
                Instantiate(Effect_08_Top, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_08_GroundSlash(Clone)"), 1.5f);
            }*/
            else if (Input.GetKeyDown(KeyCode.U) && 控制器.GetCurrentAnimatorStateInfo(0).IsName("連打") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("右出拳") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("膝擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("踢擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大絕") == false
                && seanSkillU.isStartTime == false)
            {
                seanSkillU.isStartTime = true;
                控制器.SetBool("連打", true);
                Instantiate(Effect_36_TOP_1, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_36_MadnessSlash(Clone)"), 2f);
            }
            else if (Input.GetKeyDown(KeyCode.I) && 控制器.GetCurrentAnimatorStateInfo(0).IsName("大絕") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("右出拳") == false && 控制器.GetCurrentAnimatorStateInfo(0).IsName("膝擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("踢擊") == false
                && 控制器.GetCurrentAnimatorStateInfo(0).IsName("連打") == false
                && seanSkillI.isStartTime == false)
            {
                seanSkillI.isStartTime = true;
                控制器.SetBool("大絕", true);
                Instantiate(Effect_21_TOP_1, RolePosition.transform.position, RolePosition.transform.rotation);
                Destroy(GameObject.Find("Effect_21_GroundScatter(Base)(Clone)"), 5f);
            }
            else
            {
                控制器.SetBool("右出拳", false);
                控制器.SetBool("踢擊", false);
                控制器.SetBool("連打", false);
                控制器.SetBool("膝擊", false);
                控制器.SetBool("大絕", false);
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
        if (other.gameObject.tag == "sean3")
        {
            HP -= 90;
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
        if (other.gameObject.tag == "P2siro2")
        {
            HP -= 70;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "P2siro3")
        {
            HP -= 150;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "P2siro4")
        {
            HP -= 150;
            血量計.value = HP;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "P2siro5")
        {
            HP -= 250;
            血量計.value = HP;
            Debug.Log(HP);
        }
    }
}
