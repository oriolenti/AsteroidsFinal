using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject asteroide;
    public float limit_x = 10;
    public float limit_y = 6;
    public int max = 2;

    public int asteroides_actuales = 0;

    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        if(asteroides_actuales <= 0)
        {
            for (int i = 0; i < max; i++)
            {
                Vector3 pos = new Vector3(Random.Range(-limit_x, limit_x), Random.Range(-limit_y, limit_y));
                while (Vector3.Distance(pos, Vector3.zero) < 4f)
                {
                    pos = new Vector3(Random.Range(-limit_x, limit_x), Random.Range(-limit_y, limit_y));
                }
                GameObject temp = Instantiate(asteroide, pos, Quaternion.identity);
                temp.GetComponent<AsteroidController>().manager = this;
            }
            max++;
        }
        
    }
}
