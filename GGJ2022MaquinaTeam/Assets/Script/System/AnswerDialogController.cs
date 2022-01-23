using UnityEngine;

public class AnswerDialogController : MonoBehaviour
{
    private DialogueAnswer answer;

    public void SelectAnswer()
    {
        ActiveEffectByAnswer();
    }

    public void SetAnswer(DialogueAnswer answer)
    {
        this.answer = answer;
    }

    private void ContinueDialogue()
    {
        Dialogue dialogueContinue;
        GameObject dialogManager = GameObject.FindGameObjectWithTag("GameManager");

        if (dialogManager.GetComponent<DialogManager>() && dialogManager.GetComponent<DialogSystem>())
        {
            dialogueContinue = dialogManager.GetComponent<DialogManager>().FindDialogueById(answer.idDialogueContinue);
            dialogManager.GetComponent<DialogSystem>().EstablecerDialogo(dialogueContinue);
            dialogManager.GetComponent<DialogSystem>().StartDialogue();
        }
    }

    private void ActiveEffectByAnswer()
    {
        ContinueDialogue();
        SetEventToManager();
    }

    private void SetEventToManager()
    {
        GameObject eventManager = GameObject.FindGameObjectWithTag("GameManager");

        if (eventManager.GetComponent<EventController>())
        {
            eventManager.GetComponent<EventController>().addEventNPcToQueue(answer.idSpeaker,answer.idEventoToStart);
        }
    }

}