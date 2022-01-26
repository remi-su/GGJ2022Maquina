using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_level : MonoBehaviour
{
    [SerializeField] private string level;

    public void inicio()
    {
        Level_Loader.Load_Level(level);
    }

    



}
