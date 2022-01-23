using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    public List<Dialogue> lstAllDialogues;
    public List<NarrativeDialogue> lstAllNarrativeDialogues;
    public List<OptionalDialogue> lstAllOptionalDialogues;

    // Start is called before the first frame update
    void Start()
    {
        lstAllDialogues = new List<Dialogue>();
        lstAllDialogues.AddRange(lstAllNarrativeDialogues);
        lstAllDialogues.AddRange(lstAllOptionalDialogues);
    }

    //Método que busca un determinado dialogo a través de su identificador.
    public Dialogue FindDialogueById(int idDialogue)
    {
        return lstAllDialogues.Find(x => x.idDialogue == idDialogue);
    }
}
