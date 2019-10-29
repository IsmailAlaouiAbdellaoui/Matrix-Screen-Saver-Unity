using UnityEngine;
using UnityEngine.Jobs;
using Unity.Burst;
using Unity.Jobs;
using Unity.Collections;
using System;


public struct SwitchingJob : IJob
{
    [ReadOnly]//to avoid ambiguity with System.componentModel
    public int type;

    [ReadOnly]
    public int framecount;

    [ReadOnly]
    public int switchinterval;

    //[ReadOnly]
    public GameObject textprefab;

    
    

    public void Execute()
    {
        //public Random r = new Random();
    TextMesh t = (TextMesh)textprefab.GetComponent(typeof(TextMesh));
        if (framecount % switchinterval == 0)
        {
            //Debug.Log(Time.fram)
            //if (type == 0)
            //{
            //    t.text = RandomKatakana();
            //}
            //else if (type == 1)
            //{
            //    t.text = RandomGreek();
            //}
            //else if (type == 2)
            //{
            //    t.text = RandomArabic();
            //}
            //else if (type == 3)
            //{
            //    t.text = RandomChinese();
            //}
            //else
            //{
            //    t.text = RandomArmenian();
            //}
            t.text = RandomKatakana();
        }
    }
    

    public string RandomKatakana()
    {
        return ((char)Convert.ToInt32(UnityEngine.Random.Range(12448, 12529))).ToString();
    }
    //public string RandomGreek()
    //{

    //    return ((char)random.Next(931, 1024)).ToString();

    //}
    //public string RandomChinese()
    //{
    //    return ((char)random.Next(11904, 11983)).ToString();
    //}
    //public string RandomArabic()
    //{
    //    var n = random.Next(0, 5);
    //    if (n >= 2)
    //    {
    //        return ((char)random.Next(1568, 1611)).ToString();
    //    }
    //    else
    //    {
    //        return ((char)random.Next(1632, 1642)).ToString();
    //    }
    //}
    //public string RandomArmenian()
    //{

    //    return ((char)random.Next(1329, 1367)).ToString();


    //}
}
