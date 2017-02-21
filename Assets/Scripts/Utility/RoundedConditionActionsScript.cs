using UnityEngine;
using System.Collections;

public abstract class RoundedConditionActionsScript : ConditionActionsScript {

    public static event Condition OnRoundWin;
    public static event Condition OnNextRound;
    public static event Condition OnStartNewRound;

    protected override void AddConditionsMethods()
    {
        base.AddConditionsMethods();
        OnRoundWin += WinRound;
        OnNextRound += NextRound;
        OnStartNewRound += StartNewRound;
    }

    protected override void Clear()
    {
        base.Clear();
        OnRoundWin = null;
        OnNextRound = null;
        OnStartNewRound = null;
    }

    protected abstract void NextRound();

    protected abstract void StartNewRound();

    protected virtual void WinRound()
    {
        StandByGame();
    }
    
    // Invokes for delegates
    public static void WinRoundGame()
    {
        if (OnRoundWin != null)
            OnRoundWin();
    }

    public static void NextRoundGame()
    {
        if (OnNextRound != null)
            OnNextRound();
    }

    public static void StartNewRoundGame()
    {
        if(OnStartNewRound != null)
            OnStartNewRound();
    }
}
