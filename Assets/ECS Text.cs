using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

public class ECSText : ComponentSystem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        
    }


    [Serializable]
    public struct Symbol : IComponentData
    {
        //[Inject]
        //public ComponentArray<Transform> position;

        //public float x_position;
        //public float y_position;
        //public float z_position ;
        public string value ;
        public float speed ;
        //public GameObject obj ;//replace with something else (entity)
        public int switchinterval ;
        public int type ;
    }

    //[Serializable]
    //public struct Stream : IComponentData
    //{
    //    public Symbol[] symbols;
    //    public int totalsymbols ;
    //    public float speed ;
    //    //public GameObject obj ;//replace with something else( entity )
    //    public string type_characters ;
    //    public int type ;
    //}

    [Serializable]
    public struct SpawnConfig : IComponentData
    {
        public float x;
        public float z;
        public int columns;
        public int rows;

        public void MatrixSpawner()
        {
            //var entityMangager = World.Active.GetOrCreateManager<EntityManager>();

            //for (int i = 0; i < columns; i++)
            //{
            //    for (int j = 0; j < rows; j++)
            //    {
            //        //var stream_temp = new Stream(TextRain);
            //        //stream_temp.generateSymbols(x, (float)random.Next(40, 60), z);//y = 50f
            //        //streams.Add(stream_temp);
            //        //x = x + 10;
            //    }
            //    x = 0;
            //    z = z + 10;



            //}


        }
    }

    
}
