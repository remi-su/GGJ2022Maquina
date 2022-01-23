using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public bool isPauseTimeGame;

    public bool isInteract; // Variable que determina si el personaje esta interactuando con un objeto

    public void ToggleTimeGame(bool isPauseTimeGame)
    {
        this.isPauseTimeGame = isPauseTimeGame;
    }

    public bool GetStateTimeGame()
    {
        return this.isPauseTimeGame;
    }
}
