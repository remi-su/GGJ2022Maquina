using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider loadbar;
    // Start is called before the first frame update
    void Start()
    {

        string Leveltoload = Level_Loader.next_level;
        StartCoroutine(Maketheload(Leveltoload));

    }

    IEnumerator Maketheload(string leveltoload)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(leveltoload);
        while (!operation.isDone)
        {
            loadbar.value = operation.progress /.9f;
            yield return null;
        }
    }
}
