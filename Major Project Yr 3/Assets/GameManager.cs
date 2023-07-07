using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        Intro = 0,
        GamePlay,
        GamePause,
        CutScene,
        //Create seperate states for transition during each cutscene
        //New states here
        //States for camera cut scenes also need to go here (for now, could be moved to Camera Director in the future)
        NumOfGameStates
    }


    private static GameManager instance;

    [SerializeField] private GameStates currentState = GameStates.Intro;
    [SerializeField] private GameObject IntroCanvas;
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private StarterAssets.StarterAssetsInputs playerInputs;

    private CameraDirector.CameraList cutsceneCamera;

    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }

    public GameStates CurrentState { get => currentState; }

    private bool DoStateTransition(GameStates newState)
    {
        if (newState == currentState) return true;
        //potential for switch statement here

        DoExitTransition(currentState);
        DoEntryTransition(newState);
        currentState = newState;

        return true;

    }

    private void DoEntryTransition(GameStates state)
    {
        switch (state)
        {
            case GameStates.Intro:
                //pause character controls
                playerInputs.cursorLocked = false;
                CameraDirector.Instance.SetCamera(CameraDirector.CameraList.IntroCam);
                break;
            case GameStates.GamePlay:
                playerInputs.cursorLocked = true;
                CameraDirector.Instance.SetCamera(CameraDirector.CameraList.PlayerCam);
                //enable player controls
                break;
            case GameStates.GamePause:
                playerInputs.cursorLocked = false;
                break;
            case GameStates.CutScene:
                StartCoroutine(doCutScene());
                break;
            case GameStates.NumOfGameStates:

            default:
                break;
        }
    }

    private void DoExitTransition(GameStates state)
    {
        switch (state)
        {
            case GameStates.Intro:
                IntroCanvas.SetActive(false);
                break;
            case GameStates.GamePlay:
                //pause character controls
                break;
            case GameStates.GamePause:
                break;
            case GameStates.CutScene:
                break;
            case GameStates.NumOfGameStates:

            default:
                break;
        }
    }

    private void DoCyclicActions(GameStates state)
    {
        switch (state)
        {
            case GameStates.Intro:
                break;
            case GameStates.GamePlay:
                break;
            case GameStates.GamePause:
                break;
            case GameStates.CutScene:
                break;
            case GameStates.NumOfGameStates:

            default:
                break;
        }
    }

    private void Awake()
    {
        PauseCanvas.SetActive(false);
        IntroCanvas.SetActive(true);
    }

    public void StartGameButton()
    {
        if (currentState != GameStates.Intro)
            return;
        DoStateTransition(GameStates.GamePlay);
    }

    public void StartCutscene(CameraDirector.CameraList cutsceneCam)
    {
        if (currentState != GameStates.GamePlay)
            return;
        cutsceneCamera = cutsceneCam;
        DoStateTransition(GameStates.CutScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoCyclicActions(currentState);

    }

    IEnumerator doCutScene()
    {

        CameraDirector.Instance.SetCamera(cutsceneCamera);
        while (CameraDirector.Instance.GetIsLive(CameraDirector.CameraList.PlayerCam)== true)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(7f);
        CameraDirector.Instance.SetCamera(CameraDirector.CameraList.PlayerCam);
        while (CameraDirector.Instance.GetIsLive(cutsceneCamera) == true)
        {
            yield return new WaitForEndOfFrame();
        }
        DoStateTransition(GameStates.GamePlay);
    }

    //Code design credit goes to Craig Zeki - many thanks!
}
