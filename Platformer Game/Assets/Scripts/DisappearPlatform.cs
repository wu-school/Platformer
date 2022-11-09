using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float lifespan = 5;
    float time; 
    void Start()
    {
        time = 0;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= lifespan)
        {
            Destroy(gameObject);
        }
    }
}
