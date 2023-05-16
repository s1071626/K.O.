using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    VideoPlayer playVideo = new VideoPlayer();

    public float VideoTime = 2.0f;//定義技能的結束時間
    private float timer = 0;//定義計時器
    public static bool isStartTime = true;
    void Start()
    {
        playVideo = GetComponent<VideoPlayer>();
    }
    void Update()
    {
        if (isStartTime)//當開始計時時執行下列代碼
        {
            timer += Time.deltaTime;
            if (timer >= VideoTime)//判断是否達到冷卻時間
            {
                timer = 0;//重置計算器
                playVideo.Stop();
                isStartTime = false;//結束計時
            }
        }
    }
}
