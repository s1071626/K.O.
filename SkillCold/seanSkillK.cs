using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seanSkillK : MonoBehaviour
{
    public float coldTime = 2.0f;//定義技能的冷卻時間
    private float timer = 0;//定義計時器
    private Image filledImage;//定義一個填充圖片，下面從start方法裡獲取實例中的填充圖片
    public static bool isStartTime = false;//定義標誌量，决定是否開始計時
    void Start()
    {
        filledImage = transform.Find("FillImage").GetComponent<Image>();//用transform中的Find方法獲取名為FillImage物體中Image組件；
    }
    void Update()
    {
        if (isStartTime)//當開始計時時執行下列代碼
        {
            timer += Time.deltaTime;
            filledImage.fillAmount = (coldTime - timer) / coldTime;//按照時間比例顯示圖片，剛開始點擊時，timer小，應該顯示的背景圖大
            if (timer >= coldTime)//判断是否達到冷卻時間
            {
                filledImage.fillAmount = 0;//冷卻不顯示
                timer = 0;//重置計算器
                isStartTime = false;//結束計時
            }
        }

    }
}
