using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public PlatformGenerator myGen;
    public TextMeshProUGUI myGUI;

    // Start is called before the first frame update
    void Start()
    {
        myGen = GameObject.FindGameObjectsWithTag("Controller")[0].GetComponent<PlatformGenerator>();
        myGUI.text = "You LOST! Score:" + myGen.points;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
