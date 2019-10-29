using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //public float x;
    //public float z;
    public int columns = 5;
    public int rows = 5;
    public GameObject TextRain;



    void Start()
    {
        MatrixSpawn();
    }


    void Update()
    {
        
    }
    void MatrixSpawn()
    {
        float x = 0;
        float z = 150f;
        float y;
        System.Random r = new System.Random();
        var totalsymbols = r.Next(7, 19);
        //var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        //NativeArray<Entity> StreamArray = new NativeArray<Entity>(rows*columns, Allocator.Persistent);
        //NativeArray<Entity> SymbolsArray = new NativeArray<Entity>(totalsymbols, Allocator.Persistent);
        //NativeArray<Entity> 
        //entityManager.Instantiate(TextRain, StreamArray);
        //entityManager.Instantiate(TextRain, SymbolsArray);
        float[] speeds = new float[] { 0.1f, 0.3f, 0.6f };
        byte[] value;
        for (int i = 0; i < rows * columns; i++)
        {

            
            //entityManager.SetComponentData(StreamArray[i], new Stream { speed = r.Next(0,2) });
            //entityManager.SetComponentData(StreamArray[i], new Stream { type = r.Next(0, 5) });
            //entityManager.SetComponentData(StreamArray[i], new Stream { totalsymbols = r.Next(7, 19) });
            //entityManager.SetComponentData(StreamArray[i], new Stream { obj = TextRain });
            //entityManager.SetComponentData(StreamArray[i], new Stream {   });
            y = (float)r.Next(40, 60);
            for (int k = 0; k< r.Next(7, 19); k++)
                {
                    var type = r.Next(0, 5);
                    if (type == 0)
                    {
                        value = BitConverter.GetBytes(RandomKatakana());
                    }
                    else if (type == 1)
                    {
                        value = BitConverter.GetBytes(RandomGreek());
                    }
                    else if (type == 2)
                    {
                        value = BitConverter.GetBytes(RandomArabic());
                    }
                    else if (type == 3)
                    {
                        value = BitConverter.GetBytes(RandomChinese());
                    }
                    else
                    {
                        value = BitConverter.GetBytes(RandomArmenian());
                    }


                //entityManager.SetComponentData(SymbolsArray[i], new Symbol {position = vtemp })
                //entityManager.AddComponentData(SymbolsArray[i], new Symbol {x=x });
                //    entityManager.AddComponentData(SymbolsArray[i], new Symbol {y=y });
                //    entityManager.AddComponentData(SymbolsArray[i], new Symbol {z=z });
                //    entityManager.AddComponentData(SymbolsArray[i], new Symbol {speed = r.Next(0, 2) });
                //    entityManager.AddComponentData(SymbolsArray[i], new Symbol { type = r.Next(0, 5) });
                //    entityManager.AddComponentData(SymbolsArray[i], new Symbol { switchinterval = r.Next(2, 25) });
                //entityManager.AddComponentData(SymbolsArray[i], new Symbol { value = value });
                    y -= 2f;
                }
                //entityManager.SetComponentData(SymbolsArray[i], new Symbol { x = x });
                //entityManager.SetComponentData(SymbolsArray[i], new Symbol { y = (float)r.Next(40, 60) });
                //entityManager.SetComponentData(SymbolsArray[i], )

                //entityManager.SetComponentData(StreamArray[i], new Stream { type = r.Next(0, 5) });
                //entityManager.AddComponentData(StreamArray[i], new Stream { type = r.Next(0, 5) });
                //var stream_temp = new Stream(TextRain);
                //stream_temp.generateSymbols(x, (float)random.Next(40, 60), z);//y = 50f
                //streams.Add(stream_temp);
                x = x + 10;
            if ((rows * columns) % rows == 0)
            {
                x = 0;
                z = z + 10;
            }
                



        }


        //SymbolsArray.Dispose();



    }
    System.Random random = new System.Random();
    public char RandomKatakana()
    {
        return ((char)random.Next(12448, 12529));
    }
    public char RandomGreek()
    {

        return ((char)random.Next(931, 1024));

    }
    public char RandomChinese()
    {
        return ((char)random.Next(11904, 11983));
    }
    public char RandomArabic()
    {
        var n = random.Next(0, 5);
        if (n >= 2)
        {
            return ((char)random.Next(1568, 1611));
        }
        else
        {
            return ((char)random.Next(1632, 1642));
        }
    }
    public char RandomArmenian()
    {

        return ((char)random.Next(1329, 1367));


    }
}
