using UnityEngine;

public abstract class ManagerBase : MonoBehaviour , Initialize
{
    public string managerKey {get; private set;}
    public virtual void Init()
    {
        Debug.Log($"{this.GetType().Name} Init");
    }
}
