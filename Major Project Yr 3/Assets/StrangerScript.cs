using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class StrangerScript : MonoBehaviour
{
    public NPCConversation secondConversation;

    private void OnMouseOver()
    {
        ConversationManager.Instance.StartConversation(secondConversation);
    }
}
