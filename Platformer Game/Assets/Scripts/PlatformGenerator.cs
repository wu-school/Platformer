using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlatformGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject platform;
    public int points;
    public TextMeshProUGUI myTextMesh;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("newPlatform", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        myTextMesh.text = "Score: " + points;
    }

    void newPlatform()
    {
        points++;
        GameObject neuPlatform;

        while (true)
        {
            Vector3 newPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-3f, 3f), 0);
            if(Mathf.Pow((float)(transform.position.y - newPosition.y), 2) < 9 && Mathf.Pow((float)(transform.position.x - newPosition.x), 2) > 4)
            {
                Debug.Log(transform.position);
                Debug.Log("new platmor at " + newPosition);
                neuPlatform = Instantiate(platform, newPosition, Quaternion.identity);
                platform = neuPlatform;
                break;
            } 
        }
        
    }

    public void stopGeneration()
    {
        CancelInvoke();
        CancelInvoke("newPlatform");
        Debug.Log("stopping generation");
    }
}
