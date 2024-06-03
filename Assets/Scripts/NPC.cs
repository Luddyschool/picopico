using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioImageSynchronizer : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource audioSource;
    public List<AudioClip> audioClips;

    [Header("Image Settings")]
    public List<Sprite> images;
    public Image imageComponent;

    private int currentIndex = 0;

    void Start()
    {
        // 确保至少有一个音频片段和一个图像
        if (audioClips.Count == 0 || images.Count == 0 || audioSource == null || imageComponent == null)
        {
            Debug.LogError("Missing required components or clips/images");
            return;
        }

        StartCoroutine(PlayAudioAndSwitchImages());
    }

    // 协同程序，用来依次播放音频和切换图片
    IEnumerator PlayAudioAndSwitchImages()
    {
        while (true)
        {
            if (currentIndex < audioClips.Count && currentIndex < images.Count)
            {
                audioSource.clip = audioClips[currentIndex];
                audioSource.Play();

                // 切换到当前索引的图像
                imageComponent.sprite = images[currentIndex];

                // 等待音频播放完毕
                yield return new WaitForSeconds(audioSource.clip.length);

                currentIndex++;
            }
            else
            {
                // 当所有音频和图像都播放完成时，循环重新开始
                currentIndex = 0;
            }
        }
    }
}