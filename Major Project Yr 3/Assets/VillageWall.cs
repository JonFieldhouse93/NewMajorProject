using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class VillageWall : MonoBehaviour
{

    [SerializeField] CameraDirector.CameraList villageCam;

    private bool cutsceneComplete = false;

    public PlayableDirector villageCS;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Village Wall triggered");
        if (cutsceneComplete)
            return;
        GameManager.Instance.StartCutscene(villageCam);
        PlayableDirector pd = villageCS.GetComponent<PlayableDirector>();
        if (pd != null)
        {
            pd.Play();
        }
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
