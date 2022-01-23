using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPCProfile npcProfile;
    private int idDialogue;
    // Start is called before the first frame update
    void Start()
    {
        idDialogue = npcProfile.idDialogueInitial;
    }

    public int getIdDialogue()
    {
        return idDialogue;
    }
}
