using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Reset : MonoBehaviour
{
    [SerializeField] Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(ResetGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetGame()
    {
        SceneManager.LoadScene("Game");
        Destroy(GameObject.FindGameObjectsWithTag("GameController")[0]);
    }
}
