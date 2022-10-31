using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject platform;
    void Start()
    {
        InvokeRepeating("newPlatform", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void newPlatform()
    {
        Instantiate(platform, new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 0), Quaternion.identity);
    }
}
