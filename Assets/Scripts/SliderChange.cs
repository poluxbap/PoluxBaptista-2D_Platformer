using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderChange : MonoBehaviour
{
    public AudioMixer group;
    public string soundType;

    public void SliderUpdate(float f)
    {
        group.SetFloat(soundType, f);
    }
}
