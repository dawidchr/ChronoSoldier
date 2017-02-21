using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionActionsScript : MonoBehaviour
{
    public delegate void Condition();
    public static event Condition OnReplay;
    public static event Condition OnLose;
    public static event Condition OnWin;
    public static event Condition OnStartGameplay;
    public static event Condition OnResume;
    public static event Condition OnPause;
    public static event Condition OnLeave;
    public static event Condition OnStandby;
    public static event Condition OnSceneStart;

    public static event Condition OnResetInScene;

    public static bool gameStandby;

    private static bool gameplayEnabled;

    List<IResetable> resetableObjects;

    public static bool GameplayEnabled
    {
        get { return gameplayEnabled; }
        set { gameplayEnabled = value; }
    }

    public static bool StopAnimation { get; private set; }

    protected virtual void Awake()
    {
        AddResetableInterface();
    }

    public static void StopAnimations()
    {
        StopAnimation = true;
    }

    public static void StartAnimations()
    {
        StopAnimation = false;
    }

    private void AddResetableInterface()
    {
        resetableObjects = new List<IResetable>();
        var components = GetComponents<MonoBehaviour>();
        foreach (var component in components)
        {
            if (component is IResetable)
                resetableObjects.Add(component as IResetable);
        }
    }

    public void UseResetableInScene()
    {
        foreach (IResetable resetable in resetableObjects)
            resetable.ResetScriptInSceneAction();
    }

    private void UseResetableOnSceneLoad()
    {
        foreach (IResetable resetable in resetableObjects)
            resetable.ResetScriptOnSceneLoad();
    }

    protected virtual void Start()
    {
        AddConditionsMethods();
    }

    protected virtual void AddConditionsMethods()
    {
        OnResetInScene += ResetInScene;
        OnWin += Win;
        OnLose += Lose;
        OnLeave += Leave;
        OnReplay += Replay;
        OnPause += Pause;
        OnResume += Resume;
        OnStandby += Standby;
        OnStartGameplay += StartGameplay;
    }

    protected virtual void Clear()
    {
        OnResume = null;
        OnPause = null;
        OnStandby = null;
        OnStartGameplay = null;
        OnReplay = null;
        OnLose = null;
        OnWin = null;
        OnLeave = null;
    }

    protected virtual void Leave()
    {

        UseResetableOnSceneLoad();
        Clear();
    }

    protected virtual void LeaveToDefaultScene()
    {
        Clear();
    }

    protected virtual void Starter()
    {
        StartGame();
    }

    protected virtual void Lose()
    {
        Standby();
    }

    protected virtual void Pause()
    {
        GameplayEnabled = false;
  
    }

    protected virtual void Replay()
    {
        UseResetableInScene();
        UseResetableOnSceneLoad();
        Clear();
    }

    protected virtual void Resume()
    {
        GameplayEnabled = true;
        gameStandby = false;
    }

    protected virtual void Standby()
    {
        GameplayEnabled = false;
        gameStandby = true;
    }

    protected virtual void StartGameplay()
    {
        GameplayEnabled = true;
        gameStandby = false;
    }

    protected virtual void Win()
    {
        Standby();
    }

    // Invokes for delegates
    public static void WinGame()
    {
        if (OnWin != null)
        {
            OnWin();
        }
    }

    public static void StartGame()
    {
        if (OnSceneStart != null)
            OnSceneStart();
    }

    public static void PauseGame()
    {
        if (OnPause != null)
            OnPause();
    }

    public static void ResumeGame()
    {
        if (OnResume != null)
            OnResume();
    }

    public static void StartGameplayGame()
    {
        if (OnStartGameplay != null)
            OnStartGameplay();
    }

    public static void ReplayGame()
    {
        if (OnReplay != null)
            OnReplay();
    }

    public static void LoseGame()
    {
        if (OnLose != null)
            OnLose();
    }

    public static void LeaveGame()
    {
        if (OnLeave != null)
            OnLeave();
    }

    public static void StandByGame()
    {
        if (OnStandby != null)
            OnStandby();
    }

    public static void ResetInScene()
    {
        if (OnResetInScene != null)
            OnResetInScene();
    }
}
