using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpin : MonoBehaviour
{
    [SerializeField]
    float spinSpeed = 0;//���]���x
    void Start()
    {
        
    }

    void Update()
    {
        Transform earthTransform = this.transform;

        earthTransform.Rotate(0, -spinSpeed, 0);//"-"�ɂ�莩�]���Č�
    }
}
