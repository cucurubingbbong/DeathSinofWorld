using UnityEngine;

public class TurnManager : ManagerBase
{
    [SerializeField] private TurnStateType currentTurnState;

    public override void Init()
    {
        currentTurnState = TurnStateType.TurnStart;
    }
}
