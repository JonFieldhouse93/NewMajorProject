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

    private void OnEnable()
    {
        ConversationManager.OnConversationStarted += ConversationStart;
        ConversationManager.OnConversationEnded += ConversationEnd;
    }

    private void OnDisable()
    {
        ConversationManager.OnConversationStarted -= ConversationStart;
        ConversationManager.OnConversationEnded -= ConversationEnd;
    }


    private void ConversationStart()
    {
        Debug.Log("Conversation started");
    }

    private void ConversationEnd()
    {
        Debug.Log("Conversation ended");
    }
}
