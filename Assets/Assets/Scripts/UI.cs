using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text puntuacion;
    public TMP_Text lifes;

    public GameObject startButton;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = GameManager.instance.punt.ToString();

        lifes.text = GameManager.instance.life.ToString();
    }


    public void StartGame()
    {
        Debug.Log("Game Started");
        startButton.SetActive(false);
     }
}