using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    private List<EventDescription> listIdNPCEvents;
    private List<EventDescription> listIdEnviromentEvents;
    private bool isTimeStop;

    // Start is called before the first frame update
    void Start()
    {
        listIdNPCEvents = new List<EventDescription>();
        listIdEnviromentEvents = new List<EventDescription>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

        if (gameManager.GetComponent<GameManager>())
        {
            isTimeStop = gameManager.GetComponent<GameManager>().GetStateTimeGame();
        }

        if (isTimeStop)
        {
            return;
        }

        if (listIdNPCEvents.Count != 0)
        {
            ExecuteNPCEvent();
        }

        if (listIdEnviromentEvents.Count != 0)
        {
            ExecuteEnviroment();
        }

    }

    public void addEventNPcToQueue(int idUserNPC, int idEvent)
    {
        EventDescription newEvent;
        if (!listIdNPCEvents.Exists(x => x.idObjectEvent == idUserNPC))
        {
            newEvent = new EventDescription();
            newEvent.idEvent = idEvent;
            newEvent.idObjectEvent = idUserNPC;

            listIdNPCEvents.Add(newEvent);
        }
    }

    private void ExecuteNPCEvent()
    {
        EventDescription firstID = listIdNPCEvents[0];
        GameObject npc = GameObject.Find("NPC_" + firstID.idObjectEvent);

        if (npc != null)
        {
            if (npc.GetComponent<IEventExecuter>() != null)
            {
                npc.GetComponent<IEventExecuter>().ExecuterEvent(firstID.idEvent);
            }
        }

        listIdNPCEvents.Remove(firstID);
    }

    private void ExecuteEnviroment()
    {
        EventDescription firstID = listIdEnviromentEvents[0];
        GameObject enviroment = GameObject.Find("Enviroment_" + firstID.idObjectEvent);

        if (enviroment.GetComponent<IEventExecuter>() != null)
        {
            enviroment.GetComponent<IEventExecuter>().ExecuterEvent(firstID.idEvent);
        }

        listIdEnviromentEvents.Remove(firstID);
    }

    public void addEventEnviromentToQueue(int idEnviroment, int idEvent)
    {
        EventDescription newEvent;
        if (!listIdEnviromentEvents.Exists(x => x.idObjectEvent == idEnviroment))
        {
            newEvent = new EventDescription();
            newEvent.idEvent = idEvent;
            newEvent.idObjectEvent = idEnviroment;
            listIdEnviromentEvents.Add(newEvent);
        }
    }

}
