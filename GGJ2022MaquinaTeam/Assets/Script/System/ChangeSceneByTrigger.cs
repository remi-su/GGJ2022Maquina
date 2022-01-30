using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneByTrigger : MonoBehaviour
{
    public string NextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Time.timeScale = 1f;
            Level_Loader.Load_Level(NextScene);
        }
    }
}
