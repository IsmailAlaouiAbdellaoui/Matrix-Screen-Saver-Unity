using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static System.Random random = new System.Random();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

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
        public bool isfirst { get; set; }


        public Symbol(float x, float y, float z, float velocity, GameObject TextRain, int typec, bool first)
        {

            x_position = x;
            y_position = y;
            z_position = z;
            speed = velocity;
            type = typec;
            isfirst = first;

            if (type == 0)
            {
                value = randomKatakana();
            }
            switchinterval = random.Next(2, 25);
            obj = Instantiate(TextRain, new Vector3(x_position, y_position, z_position), TextRain.transform.rotation);


        }

        public void ChangeSymbol()
        {
            TextMesh t = (TextMesh)obj.GetComponent(typeof(TextMesh));

            Color c = new Color(0f / 255f, 255f / 255f, 125f / 255f, 0.8f);
            Color blueish = new Color(7f / 255f, 127f / 255f, 117f / 255f);
            Color cfirst = new Color(180f / 255f, 255f / 255f, 180f / 255f, 1f);

            if(isfirst)
            {
                t.color = cfirst;
            }
            else
            {
                t.color = blueish;
            }

            if(Time.frameCount % switchinterval == 0)
            {
                if(type == 0)
                {
                    t.text = randomKatakana();
                }
            }

        }


        public string randomKatakana()
        {
            return ((char)random.Next(12448, 12529)).ToString();
        }

    }

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
            float[] speeds = new float[] { 1f, 3f, 6f };
            totalsymbols = random.Next(7, 10);
            speed = speeds[random.Next(0, 3)];
            obj = character;
            type = 0;
        }

        public void generateSymbols(float x, float y, float z)
        {
            bool isfirst = false;
            for (int i = 0; i < totalsymbols; i++)
            {
                if(i == totalsymbols -1)
                {
                    isfirst = true;
                }
                Symbol s = new Symbol(x, y, z, speed, obj, type, isfirst);
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

    

}
