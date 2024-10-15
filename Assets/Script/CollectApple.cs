using UnityEngine;
using UnityEngine.UI; // 引用UI命名空间

public class CollectApple : MonoBehaviour
{
    public int appleCount = 0; // 放入篮筐中的苹果数量
    //public GameObject completionUI; // 完成时显示的UI提示
    public GameObject completionEffect; // 完成时播放的特效
    public AudioSource completionAudio; // 完成时播放的音频

    void OnTriggerEnter(Collider other)
    {
        // 检查进入篮筐的对象是否是苹果
        if (other.gameObject.CompareTag("Apple"))
        {
            appleCount++; // 增加苹果计数
            other.gameObject.SetActive(false); // 隐藏苹果对象

            // 检查苹果数量是否达到3个
            if (appleCount >= 3)
            {
                ShowCompletionEffect(); // 显示完成特效
            }
        }
    }

    void ShowCompletionEffect()
    {
        if (completionEffect != null)
        {
            Instantiate(completionEffect, transform.position, Quaternion.identity); // 在篮筐位置播放特效
        }
        if (completionAudio != null)
        {
            completionAudio.Play(); // 播放完成音频
        }
    }
}