using UnityEngine;

public abstract class GlobalManagerBase<T> : ManagerBase where T : GlobalManagerBase<T>
{
    public static T Instance { get; private set; }

    public override void Init()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"An instance of {typeof(T).Name} already exists. Destroying the new instance.");
            Destroy(gameObject);
            return;
        }

        Instance = (T)this;
        DontDestroyOnLoad(gameObject);
        OnInit();
    }

    protected abstract void OnInit();
}
