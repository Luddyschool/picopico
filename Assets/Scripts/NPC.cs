using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource audioSource;
    public List<AudioClip> audioClips;

    [Header("Image Settings")]
    public List<Sprite> images;
    public Image imageComponent;

    private int currentIndex = 0;

    [Header("TOSORT/")]
    public bool isPlayerNearby;
    public GameObject player;
    public float dialogueTriggeringDistance;
    private bool isDialogueStarted;

    void Start()
    {
        // 确保至少有一个音频片段和一个图像
        
    }

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= dialogueTriggeringDistance && 
            !isDialogueStarted)
        {
            
        }

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= dialogueTriggeringDistance &&
            isDialogueStarted)
        {
            
        }

        if (isPlayerNearby)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
    */

    public void PlayAudioWhenPlayerNearby()
    {
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
        currentIndex = 0;
        while (isPlayerNearby)
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
        
        StopCoroutine(PlayAudioAndSwitchImages());
    }
    
    public void OnPlayerGazed()
    {
        isPlayerNearby = true;
        isDialogueStarted = true;
        PlayAudioWhenPlayerNearby();
    }

    public void OnPlayerStopGazed()
    {
        isPlayerNearby = false;
        isDialogueStarted = false;
    }
}