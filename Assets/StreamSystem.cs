using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using System;
using Unity.Transforms;

//public struct Stream : IComponentData
//{
//    public Symbol[] symbols;
//    //public ComponentArray symbols;
//    //List<Symbol> symbols;
//    public int totalsymbols;
//    public float speed;
//    public GameObject obj ;//replace with something else( entity )
//    //public string type_characters;
//    public int type;

//    //public void generateSymbols(float x, float y, float z)
//    //{

//    //    for (int i = 0; i < totalsymbols; i++)
//    //    {
//    //        //Symbol s = new Symbol(x, y, z, speed, obj, type);

//    //        symbols.Add(s);
//    //        y -= 2f;
//    //    }

//    //}


//}

[Serializable]
public struct Symbol : IComponentData
{
    //[Inject]
    //public ComponentArray<Transform> position;
    public ComponentDataArray<Position> position;

    public float x;
    public float y;
    public float z;
    //public string value;
    public byte[] value;
    public float speed;
    public GameObject obj;//replace with something else (entity)
    public int switchinterval;
    public int type;
}



public struct SymbolsPosition : IComponentData
{
    //[Inject]
    //public ComponentArray<Transform> position;
    public float x;
    public float y;
    public float z;
}

//public class StreamSystem : JobComponentSystem
//{
//    public static GameObject TextRain;

//    public struct generateSymbolsJob : IJobProcessComponentData<SymbolsPosition,Stream>
//    {
//        public void Execute(ref SymbolsPosition pos, ref Stream stream)//Execute needs to be implemented
//        {
//            var entityMangager = World.Active.GetOrCreateManager<EntityManager>();

//            //NativeArray<Entity> SymbolsArray = new NativeArray<Entity>(stream.totalsymbols, Allocator.Temp);
//            //entityMangager.Instantiate(TextRain, SymbolsArray);
//            for (int i = 0; i < stream.totalsymbols; i++)
//            {
//                //entityMangager.SetComponentData(SymbolsArray[i],new Symbol {x =  });
//                //Symbol s = new Symbol(x, y, z, speed, obj, type);******
//                //symbols.Add(s);******
//                pos.y -= 2f;
//            }
//        }
//    }
//}
