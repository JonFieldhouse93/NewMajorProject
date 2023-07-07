using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class enemyCS : MonoBehaviour
{

    [SerializeField] CameraDirector.CameraList enemyCam;

    private bool cutsceneComplete = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("cutscene triggered");
        if (cutsceneComplete)
            return;
        GameManager.Instance.StartCutscene(enemyCam);
        cutsceneComplete = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
