using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider loadbar;
    [SerializeField] private Text m_Text;
    private float initialTimeWait = 2;
    // Start is called before the first frame update
    void Start()
    {
        loadbar.value = 0;
        string Leveltoload = Level_Loader.next_level;
        StartCoroutine(Maketheload(Leveltoload));

    }

    IEnumerator Maketheload(string leveltoload)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(leveltoload);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadbar.value = operation.progress / 0.9f;

            m_Text.text = "Loading progress: " + (operation.progress * 100) + "%";

            // Check if the load has finished
            if (operation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                m_Text.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
