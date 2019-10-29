using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Burst;
using Unity.Collections;

[BurstCompile]
public struct SlidingJob : IJobParallelForTransform
{
    //public float speed;
    //public Vector3 resetpos;

    [ReadOnly]
    public NativeArray<float> velocity;

    [ReadOnly]
    public NativeArray<Vector3> resetpos;

    [ReadOnly]
    public float deltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        
        transform.position -= new Vector3(0, velocity[index], 0) * deltaTime;
        if (transform.position.y <= -40)
        {
            transform.position = resetpos[index];
        }
    }
}
