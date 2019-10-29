using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using UnityEngine.Jobs;

public class JobManager : MonoBehaviour
{
    TransformAccessArray transforms;
    SlidingJob slidingjob;
    SwitchingJob switchingjob;
    JobHandle movehandle;
    public GameObject text;
    System.Random random = new System.Random();



    private void OnDisable()
    {
        movehandle.Complete();
        transforms.Dispose();
    }

    // Start is called before the first frame update
    void Start()
    {
        transforms = new TransformAccessArray(0, -1);
        //Instantiate(text, new Vector3(0, 1, -5), text.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        movehandle.Complete();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            movehandle.Complete();
            transforms.capacity = transforms.length + 1;
            var obj = Instantiate(text, new Vector3(0, 1, -5), text.transform.rotation) as GameObject;
            transforms.Add(obj.transform);

        }

        //slidingjob = new SlidingJob()
        //{
        //    speed = 0.1f,
        //    resetpos = new Vector3(0, 1, -5)
        //};

        switchingjob = new SwitchingJob()
        {
            framecount = Time.frameCount,
            switchinterval = random.Next(2, 25),
            textprefab = text,
            type = 0

        };
        //if(transforms.length>=1)
        //{
        //    movehandle = switchingjob.Schedule();
        //}
        
        //movehandle = slidingjob.Schedule(transforms);
        JobHandle.ScheduleBatchedJobs();

    }
    //object transform ==> transforms ==> job handle
}
