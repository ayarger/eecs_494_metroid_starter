﻿/* A component that implements (and provides an API for) a screen-shake effect */
// Requires placement on a camera gameobject.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeEffect : MonoBehaviour {

    public static ScreenShakeEffect instance;

    float shake_timer = 0;
    float shake_radius = 0;
    float shake_speed = 0;

    // Note: speed currently does not affect the effect.
    // Ideally, it delays each jump of the camera by 'speed' frames.
    public static void Shake(float duration, float radius, float speed)
    {
        instance.shake_timer = duration;
        instance.shake_radius = radius;
        instance.shake_speed = speed;
    }

    // Use this for initialization
    void Start () {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        else
            instance = this;
    }
    
    // Update is called once per frame
    void Update () {
        if(shake_timer > 0)
        {
            transform.localPosition = UnityEngine.Random.onUnitSphere * shake_radius;
            shake_timer--;
        } else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}
