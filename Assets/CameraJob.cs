using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Burst;
using Unity.Collections;



[BurstCompile]
public struct CameraJob : IJobParallelForTransform
{
    [ReadOnly]
    public float deltaTime;

    [ReadOnly]
    public float time;

    [ReadOnly]
    public bool shoulddive;

    [ReadOnly]
    public bool shouldup;


    public void Execute(int index, TransformAccess transform)
    {
        float circlespeed = 0.1f;

        float circlesize = 1f;

        float verticalspeed = 3f;

        float movementspeed = 0.1f;


        //transform.position += new Vector3(-Mathf.Sin(time * circlespeed) * circlesize * movementspeed, -verticalspeed * deltaTime, Mathf.Cos(time * circlespeed) * circlesize * movementspeed);


        if (shoulddive)
        {
            transform.position += new Vector3(-Mathf.Sin(time * circlespeed) * circlesize * movementspeed, -verticalspeed * deltaTime, Mathf.Cos(time * circlespeed) * circlesize * movementspeed);
        }

        if (shouldup)
        {
            transform.position += new Vector3(-Mathf.Sin(time * circlespeed) * circlesize * movementspeed, verticalspeed * deltaTime, Mathf.Cos(time * circlespeed) * circlesize * movementspeed);
        }

        //transform.rotation = new Quaternion(-time * 0.1f, 0,0,1f);

    }

}
