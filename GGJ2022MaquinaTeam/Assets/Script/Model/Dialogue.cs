
using UnityEngine;
using System;

[Serializable]
public class Dialogue
{
    [SerializeField]
    public int idDialogue;
    [SerializeField]
    public string nameSpeaker;
    [SerializeField]
    public string[] sentences;
}

[Serializable]
public class NarrativeDialogue: Dialogue
{
    [SerializeField]
    public int nextDialogue;
}

[Serializable]
public class OptionalDialogue: Dialogue
{
    [SerializeField]
    public DialogueAnswer[] answers;
}

[Serializable]
public class DialogueAnswer
{
    [SerializeField]
    public int idAnswer; //Identificador de la respuesta.
    [SerializeField]
    public string answerSentence; //Oración de la respuesta.
    [SerializeField]
    public int idDialogueContinue; //Dialogo que el personaje responde con relación a la respuesta elegida por el jugador.
    [SerializeField]
    public int idEventoToStart;
    [SerializeField]
    public int idSpeaker;

}
