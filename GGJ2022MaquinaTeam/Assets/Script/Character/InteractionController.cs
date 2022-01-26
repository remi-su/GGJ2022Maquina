using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public GameObject spotToInteract;
    public LayerMask layerMask;
    private GameObject objectToInteract;
    private GameObject characterToDialogue;
    private bool isCarryObject;
    private bool isIdle;
    private bool isFolloedByNPC;
    private float lastValorAxis;

    void Start()
    {
        lastValorAxis = -1;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        bool isTimeStop = false;
        if (gameManager.GetComponent<GameManager>())
        {
            isTimeStop = gameManager.GetComponent<GameManager>().GetStateTimeGame();
        }

        if (!isTimeStop)
        {
            DetectColliderObject();
        }

    }

    //Método que determina si éxiste un objeto interactuable frente del jugador.
    private void DetectColliderObject()
    {

        float horizontalAxis = Input.GetAxis("Horizontal");
        float valorHorizontalAxis = 0;
        if (horizontalAxis > 0)
        {
            valorHorizontalAxis = -1;
            lastValorAxis = -1;
        } else if (horizontalAxis < 0)
        {
            valorHorizontalAxis = 1;
            lastValorAxis = 1;
        } else
        {
            valorHorizontalAxis = lastValorAxis;
        }

        RaycastHit2D _hit = Physics2D.Raycast(spotToInteract.transform.position, valorHorizontalAxis * Vector2.left, 1.2f, layerMask);

        if (Physics2D.Raycast(spotToInteract.transform.position, valorHorizontalAxis * Vector2.left, 1.2f, layerMask))
        {
            switch (_hit.collider.gameObject.tag)
            {
                case "Movible":
                    //ActivePusshOrPullAction(hitInfo.collider.gameObject);
                    break;
                case "NPCCharacter":
                    ActiveConversation(_hit.collider.gameObject);
                    break;
                case "Pickeable":
                    //ActiveItemIteraction(1, hitInfo.collider.gameObject);
                    break;
                case "DoorUnlocked":
                    //ActiveItemIteraction(2, hitInfo.collider.gameObject);
                    break;
                case "DoorLocked":
                    //ActiveItemIteraction(3, hitInfo.collider.gameObject);
                    break;
                case "Inspectable":
                    //InteractWithItem(hitInfo.collider.gameObject);
                    break;
                default:
                    break;
            }

            Debug.DrawRay(spotToInteract.transform.position, valorHorizontalAxis * Vector2.left * 1.2f, Color.red);
        }
        else
        {
            Debug.DrawRay(spotToInteract.transform.position, valorHorizontalAxis * Vector2.left * 1.2f, Color.green);
        }
    }

    private void ActiveConversation(GameObject NPC)
    {
        if (Input.GetButtonDown("Interact"))
        {
            Dialogue dialogueToActivate;
            int idDialogue = 0;

            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

            if (NPC.GetComponent<NPCController>())
            {
                idDialogue = NPC.GetComponent<NPCController>().getIdDialogue();
                dialogueToActivate = gameManager.GetComponent<DialogManager>().FindDialogueById(idDialogue);
                gameManager.GetComponent<DialogSystem>().EstablecerDialogo(dialogueToActivate);
                gameManager.GetComponent<DialogSystem>().StartDialogue();
            }
        }
    }
}
