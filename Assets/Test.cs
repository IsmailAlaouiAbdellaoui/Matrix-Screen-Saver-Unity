using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class Test : MonoBehaviour {

    public GameObject TextRain;


    public List<Stream> streams = new List<Stream>();
    public static System.Random random = new System.Random();


    TransformAccessArray transforms;
    NativeArray<float> m_Velocities;
    SlidingJob slidingjob;
    NativeArray<Vector3> resetpos;
    JobHandle movehandle;


    //TransformAccess transformcamera;
    TransformAccessArray transformcamera;
    CameraJob camerajob;
    JobHandle camerahandle;

    public bool shoulddive;
    public bool shouldup;




    private void OnDisable()
    {
        movehandle.Complete();
        camerahandle.Complete();

        transforms.Dispose();
        transformcamera.Dispose();
        
    }

    // Use this for initialization
    void Start() {
        transformcamera = new TransformAccessArray(1,-1);
        transformcamera.Add(Camera.main.transform);
        
        
        transforms = new TransformAccessArray(0, -1);
        //SlidingJob
        //Vector3[] vtemp;
        List<float> vtemp = new List<float>();
        List<Vector3> resetpostemp = new List<Vector3>();
        var x = 0;
        var z = 150f;
        //Debug.Log(Screen.width / 10);
        var totalsymbols = 0;


        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                var stream_temp = new Stream(TextRain);
                //stream_temp.generateSymbols(x, 100f, z);//y = 50f
                stream_temp.generateSymbols(x, (float)random.Next(90,111), z);//y = 50f

                totalsymbols += stream_temp.totalsymbols;
                for (int k = 0; k < stream_temp.symbols.Count; k++)
                {
                    transforms.capacity += 1;
                    transforms.Add(stream_temp.symbols[k].obj.transform);
                    vtemp.Add(stream_temp.symbols[k].speed);
                    resetpostemp.Add(stream_temp.symbols[k].obj.transform.position);

                }


                streams.Add(stream_temp);

                x = x + 10;
            }
            x = 0;
            z = z + 25;
        }
        m_Velocities = new NativeArray<float>(totalsymbols, Allocator.Persistent);
        m_Velocities.CopyFrom(vtemp.ToArray());

        resetpos = new NativeArray<Vector3>(totalsymbols, Allocator.Persistent);
        resetpos.CopyFrom(resetpostemp.ToArray());

        vtemp.Clear();
        vtemp = null;

        resetpostemp.Clear();
        resetpostemp = null;


        shoulddive = true;
        shouldup = false;

    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(streams.Count);

        //foreach (var s in streams)
        //{
        //    s.render();

        //}
        
        movehandle.Complete();
        camerahandle.Complete();



        slidingjob = new SlidingJob()
        {
            velocity = m_Velocities,
            resetpos = resetpos,
            deltaTime = Time.deltaTime
        };
        movehandle = slidingjob.Schedule(transforms);


        if(Camera.main.transform.position.y <= -42)
        {
            //Debug.Log("position y = 42 !");
            shouldup = true;
            shoulddive = false;
        }

        if (Camera.main.transform.position.y >= 100)
        {
            //Debug.Log("position y = 42 !");
            shouldup = false;
            shoulddive = true;
        }

        camerajob = new CameraJob()
        {
            deltaTime = Time.deltaTime,
            time = Time.time,
            shoulddive = shoulddive,
            shouldup = shouldup
        };
        camerahandle = camerajob.Schedule(transformcamera);


        JobHandle.ScheduleBatchedJobs();

        for (int i = 0; i < streams.Count; i++)
        {
            streams[i].render();
        }

        if(Input.anyKeyDown)
        {
            //Debug.Log("key pressed !");
            Application.Quit();
        }

    }
    private void OnDestroy()
    {
        m_Velocities.Dispose();
        resetpos.Dispose();
        
    }




    #region Symbol Class

    public class Symbol
        {
        public float x_position { get; set; }
        public float y_position { get; set; }
        public float z_position { get; set; }
        public string value { get; set; }
        public float speed { get; set; }
        public GameObject obj { get; set; }
        public int switchinterval { get; set; }
        public int type { get; set; }
        public TransformAccessArray test;
        public bool isfirst;



        public Symbol(float x, float y, float z, float velocity, GameObject TextRain, int typec, bool first)
        {
            
            x_position = x;
            y_position = y;
            z_position = z;
            speed = velocity;
            type = typec;
            isfirst = first;
            
            if(type == 0)
            {
                value = RandomKatakana();
            }
            else if (type ==1)
            {
                value = RandomGreek();
            }
            else if (type == 2)
            {
                value = RandomArabic();
            }
            else if (type == 3)
            {
                value = RandomChinese();
            }
            else
            {
                value = RandomArmenian();
            }

            switchinterval = random.Next(2,25);
            obj = Instantiate(TextRain, new Vector3(x_position, y_position, z_position), TextRain.transform.rotation);
            //test.Add(obj.transform);
        }

        //public void render()
        //{            
        //    TextMesh t = (TextMesh)obj.GetComponent(typeof(TextMesh));
        //    Color c = new Color(0f / 255f, 255f / 255f, 70f / 255f);
        //    t.color = c;
        //    rain();
        //}

        public void ChangeSymbol()
        {
            //if (obj.transform.position.y < -18)
            //{
            //    Vector3 vtemp = new Vector3(x_position, y_position, z_position);
            //    obj.transform.position = vtemp;
            //}

            //Vector3 v = new Vector3(obj.transform.position.x, obj.transform.position.y - speed, obj.transform.position.z);
            //obj.transform.position = v;
            TextMesh t = (TextMesh)obj.GetComponent(typeof(TextMesh));
            Color c = new Color(0f / 255f, 255f / 255f, 125f / 255f,0.8f);
            Color blueish = new Color(7f / 255f, 127f / 255f, 117f / 255f);
            Color cfirst = new Color(180f / 255f, 255f / 255f, 180f / 255f, 1f);
            if(isfirst)
            {
                t.color = cfirst;
                
            }
            else
            {
                //t.color = c;
                t.color = blueish;
            }
            
            if (Time.frameCount % switchinterval == 0)
            {
                if (type == 0)
                {
                    t.text = RandomKatakana();
                }
                else if (type == 1)
                {
                    t.text = RandomGreek();
                }
                else if (type == 2)
                {
                    t.text = RandomArabic();
                }
                else if (type == 3)
                {
                    t.text = RandomChinese();
                }
                else
                {
                    t.text = RandomArmenian();
                }
                //t.text = RandomKatakana();
            }
            
        }
        public string RandomKatakana()
        {
            return ((char)random.Next(12448, 12529)).ToString();
        }
        public string RandomGreek()
        {

            return ((char)random.Next(931, 1024)).ToString();

        }
        public string RandomChinese()
        {
            return ((char)random.Next(11904, 11983)).ToString();
        }
        public string RandomArabic()
        {
            var n = random.Next(0, 5);
            if (n >= 2)
            {
                return ((char)random.Next(1568, 1611)).ToString();
            }
            else
            {
                return ((char)random.Next(1632, 1642)).ToString();
            }
        }
        public string RandomArmenian()
        {

            return ((char)random.Next(1329, 1367)).ToString();


        }

    }
    #endregion

    #region Stream Class


    public class Stream
    {
        public List<Symbol> symbols = new List<Symbol>();
        public int totalsymbols { get; set; }
        public float speed { get; set; }
        public GameObject obj { get; set; }
        public string type_characters { get; set; }
        public int type { get; set; }

        public Stream(GameObject character)
        {
            //float[] speeds = new float[] { 0.1f, 0.3f,   0.6f };
            float[] speeds = new float[] { 1f, 3f, 6f };
            //int[] type_characters = new int[] { 0, 1, 2, 3, 4 };//0 = Katakana, 1 = Greek, 2= Chinese, 3= Arabic, 4 = Tibetan
            //string[] list_characters = new string[] {"katakana","arabic","cyrillic","chinese","" };
            totalsymbols = random.Next(7,10);
            speed = speeds[random.Next(0, 3)];
            obj = character;
            //type = random.Next(0, 5);
            type = 0;
        }

        public void generateSymbols(float x, float y, float z)
        {
            bool f = false;
            for (int i = 0; i < totalsymbols; i++)
            {
                if (i == totalsymbols - 1)
                {
                    f = true;
                }
                Symbol s = new Symbol(x, y, z, speed, obj,type,f);
                symbols.Add(s);
                y -= 2f;
                
            }

        }

        public void render()
        {

            for (int i = 0; i < symbols.Count; i++)
            {
                symbols[i].ChangeSymbol();
            }

        }

    }
    #endregion

}
