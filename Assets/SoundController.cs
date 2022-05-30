using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource[] audioList;

    public void playAudio(int ind) {
        audioList[ind].Play();
    }
}
