using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject menu_muerte;
    [SerializeField] string[] Frases;
    [SerializeField] Text texto;
    private int rand;
    private bool isPauseGame;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isPauseGame)
            {
                reanudar();
            } else
            {
                pause();
            }
        }
    }

    // Start is called before the first frame update
    //Funciones para el menu de pausa
    public void pause()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        isPauseGame = true;
    }
    public void reanudar()
    {

        Time.timeScale = 1f;
        menu.SetActive(false);
        isPauseGame = false;
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
        Time.timeScale = 1f;
        Level_Loader.Load_Level("Main_Menu");
    }

    //Funciones para el menu de muerte
    public void you_die()
    {
        menu_muerte.SetActive(true);
        menu.SetActive(false);
    }

    public void setfrase()
    {
        rand = Random.Range(0, Frases.Length);
        texto.text = Frases[rand];
    }
}
