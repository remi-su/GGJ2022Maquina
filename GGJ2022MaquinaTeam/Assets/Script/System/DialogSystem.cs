using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI textNickName;
    public GameObject[] answers;
    public GameObject[] answersBackground;
    public GameObject dialogCase;


    private Dialogue dialogue;
    private int index;
    public float typingSpeed;
    private bool isSpeaking;
    private bool isFinishSentence;

    public GameObject continueButton;

    private void Start()
    {
        HideAndResetAnswrs();
        HideDialogCase();
    }
    public void StartDialogue()
    {
        continueButton.SetActive(false);
        isFinishSentence = false;
        isSpeaking = true;
        PauseTimeGame();
        HideAndResetAnswrs();
        ShowDialogCase();
        index = 0;
        textDisplay.text = "";
        EstablecerNombreHablante();
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (isSpeaking)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isFinishSentence)
            {
                NextSentence();
            }
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in dialogue.sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueButton.SetActive(true);
        isFinishSentence = true;
    }

    //Método encargado de continuar o terminar el dialogo actual.
    public void NextSentence()
    {

        continueButton.SetActive(false);
        isFinishSentence = false;

        if (index < dialogue.sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            if (dialogue is OptionalDialogue)
            {
                SetAnswersText();
            }
            else if (dialogue is NarrativeDialogue)
            {
                SetContinueDialogue();
            }
        }

    }

    //Método que permite establecer la continuidad de los dialogos narrativos.
    private void SetContinueDialogue()
    {
        if ((dialogue as NarrativeDialogue).nextDialogue == 0)
        {
            HideDialogCase();
            ResumeTimeGame();
        }
        else
        {
            Dialogue newDialogue = GetComponent<DialogManager>().FindDialogueById((dialogue as NarrativeDialogue).nextDialogue);
            EstablecerDialogo(newDialogue);
            StartDialogue();
        }
    }

    //Método encargado de establecer las respuestas del dialogo, solo si este es del tipo OptionalDialogue.
    private void SetAnswersText()
    {
        int countAxu = 0;

        foreach (DialogueAnswer answer in (dialogue as OptionalDialogue).answers)
        {
            answers[countAxu].SetActive(true);
            //answersBackground[countAxu].SetActive(true);
            answers[countAxu].GetComponent<AnswerDialogController>().SetAnswer(answer);
            answers[countAxu].GetComponent<TextMeshProUGUI>().text = "\"" + answer.answerSentence + "\"";
            countAxu++;
        }
    }

    //Método que reinicia el texto de cada respuesta y desactiva el objeto para ocultarlo de la interfaz.
    private void HideAndResetAnswrs()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].GetComponent<TextMeshProUGUI>().text = "";
            answers[i].SetActive(false);
            //answersBackground[i].SetActive(false);
        }
    }

    //Método que permite activar y mostrar el campo de dialogo en la interfaz grafica.
    private void ShowDialogCase()
    {
        dialogCase.SetActive(true);
    }

    //Método que permite desactivar y ocultar el campo de dialogo en la interfaz grafica.
    private void HideDialogCase()
    {
        isSpeaking = false;
        dialogCase.SetActive(false);
    }

    //Método que pausa el tiempo general del juego.
    private void PauseTimeGame()
    {
        ToggleTimeGame(true);
    }

    //Método que reanuda el tiempo general del juego.
    private void ResumeTimeGame()
    {
        ToggleTimeGame(false);
    }

    //Método que permite modificar la bandera indicativa del tiempo general del juego.
    private void ToggleTimeGame(bool timeGame)
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager.GetComponent<GameManager>())
        {
            gameManager.GetComponent<GameManager>().ToggleTimeGame(timeGame);
        }
    }

    public void EstablecerDialogo(Dialogue nextDialogue)
    {
        dialogue = nextDialogue;
    }

    public void EstablecerNombreHablante()
    {
        textNickName.text = dialogue.nameSpeaker;
    }
}
