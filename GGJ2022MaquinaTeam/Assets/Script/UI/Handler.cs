using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{
    [SerializeField] GameObject boton_pausa;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject menu_muerte;
    [SerializeField] string[] Frases;
    [SerializeField] Text texto;
    private int rand;
    // Start is called before the first frame update
    //Funciones para el menu de pausa
    public void pause()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        boton_pausa.SetActive(false);

    }
    public void reanudar()
    {

        Time.timeScale = 1f;
        menu.SetActive(false);
        boton_pausa.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void restart()
    {
        Time.timeScale = 1f;
        Level_Loader.Load_Level(SceneManager.GetActiveScene().name);
    }
    public void go_to_main()
    {
        Level_Loader.Load_Level("Main_Menu");
    }

    //Funciones para el menu de muerte
    public void you_die()
    {
        menu_muerte.SetActive(true);
        boton_pausa.SetActive(false);
        menu.SetActive(false);
    }

    public void setfrase()
    {
        rand = Random.Range(0, Frases.Length);
        texto.text = Frases[rand];
    }
}
