using System;
using UnityEngine;

public abstract class ManagerBase : MonoBehaviour , Initialize
{
    [SerializeField] private EventBus sceneEventBus;
    public abstract void Init();
    public virtual void Init(EventBus sceneBus)
    {
        Debug.Log($"{this.GetType().Name}이 {sceneBus.GetType().Name}으로 초기화되었습니다.");
        sceneEventBus = sceneBus;
        Init();
    }
}
