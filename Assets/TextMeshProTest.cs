using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshProTest : MonoBehaviour
{
    public TextMeshPro tmpro;
    public GameObject TextRain;
    public Camera cam;
    public float force = 6f;
    public List<GameObject> letters;
    public static List<GameObject> letters2;
    public Symbol s;
    public Stream stream;
    public List<Stream> streams = new List<Stream>();
    public static System.Random random = new System.Random();

    // Use this for initialization
    void Start()
    {
        

        var x = 0;
        var z = 150f;
        //Debug.Log(Screen.width / 10);

        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                var stream_temp = new Stream(tmpro);
                stream_temp.generateSymbols(x, (float)random.Next(40, 60), z);//y = 50f
                streams.Add(stream_temp);
                x = x + 10;
            }
            x = 0;
            z = z + 10;



        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(streams.Count);

        foreach (var s in streams)
        {
            s.render();

        }

    }




    #region Symbol

    public class Symbol
    {
        public float x_position { get; set; }
        public float y_position { get; set; }
        public float z_position { get; set; }
        public string value { get; set; }
        public float speed { get; set; }
        public TextMeshPro obj { get; set; }
        public int switchinterval { get; set; }
        public int type { get; set; }



        public Symbol(float x, float y, float z, float velocity, TextMeshPro TextRain, int typec)
        {

            x_position = x;
            y_position = y;
            z_position = z;
            speed = velocity;
            type = typec;

            if (type == 0)
            {
                value = RandomKatakana();
            }
            else if (type == 1)
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

            switchinterval = random.Next(2, 25);
            obj = Instantiate(TextRain, new Vector3(x_position, y_position, z_position), TextRain.transform.rotation);
        }

        public void render()
        {
            //TextMesh t = (TextMesh)obj.GetComponent(typeof(TextMesh));
            Color c = new Color(0f / 255f, 255f / 255f, 70f / 255f);
            obj.color = c;
            rain();
        }

        public void rain()
        {
            if (obj.transform.position.y < -18)
            {
                Vector3 vtemp = new Vector3(x_position, y_position, z_position);
                obj.transform.position = vtemp;
            }
            Vector3 v = new Vector3(obj.transform.position.x, obj.transform.position.y - speed, obj.transform.position.z);
            obj.transform.position = v;
            //TextMesh t = (TextMesh)obj.GetComponent(typeof(TextMesh));
            if (Time.frameCount % switchinterval == 0)
            {
                if (type == 0)
                {
                    obj.text = RandomKatakana();
                }
                else if (type == 1)
                {
                    obj.text = RandomGreek();
                }
                else if (type == 2)
                {
                    obj.text = RandomArabic();
                }
                else if (type == 3)
                {
                    obj.text = RandomChinese();
                }
                else
                {
                    obj.text = RandomArmenian();
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
        public TextMeshPro obj { get; set; }
        public string type_characters { get; set; }
        public int type { get; set; }

        public Stream(TextMeshPro character)
        {
            float[] speeds = new float[] { 0.1f, 0.3f, 0.6f };
            //int[] type_characters = new int[] { 0, 1, 2, 3, 4 };//0 = Katakana, 1 = Greek, 2= Chinese, 3= Arabic, 4 = Tibetan
            //string[] list_characters = new string[] {"katakana","arabic","cyrillic","chinese","" };
            totalsymbols = random.Next(7, 19);
            speed = speeds[random.Next(0, 2)];
            obj = character;
            type = random.Next(0, 5);
            //type = 4;
        }

        public void generateSymbols(float x, float y, float z)
        {

            for (int i = 0; i < totalsymbols; i++)
            {
                Symbol s = new Symbol(x, y, z, speed, obj, type);
                symbols.Add(s);
                y -= 2f;
            }

        }

        public void render()
        {
            foreach (var s in symbols)
            {

                //TextMesh t = (TextMesh)s.obj.GetComponent(typeof(TextMesh));
                //t.text = s.value;
                Color c = new Color(0f / 255f, 255f / 255f, 70f / 255f);
                s.obj.color = c;
                s.rain();
            }
        }

    }
    #endregion
}
