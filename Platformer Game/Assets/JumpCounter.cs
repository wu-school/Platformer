using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCounter : MonoBehaviour
{

    [SerializeField] PlayerMovement myMovement;
    [SerializeField] GameObject[] jumpCounters;
    // Start is called before the first frame update
    void Start()
    {
         myMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<myMovement.jumps && i<jumpCounters.Length; i++){
            jumpCounters[i].GetComponent<SpriteRenderer>().enabled = true;
        }
        for(int i=myMovement.jumps; i<jumpCounters.Length; i++){
            jumpCounters[i].GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
