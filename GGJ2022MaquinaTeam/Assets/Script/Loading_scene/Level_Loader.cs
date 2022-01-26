using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Level_Loader
{

    public static string next_level;

    public static void Load_Level(string name)
    {
        next_level = name;
        SceneManager.LoadScene("Loading");
    }


}
