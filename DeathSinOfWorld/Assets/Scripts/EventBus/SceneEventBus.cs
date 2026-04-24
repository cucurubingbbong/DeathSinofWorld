using UnityEngine;

public class SceneEventBus : MonoBehaviour , Initialize
{
    public EventBus eventBus { get; private set; }

    public void Init()
    {
        eventBus = new EventBus();
    }

    private void OnDestroy()
    {
        eventBus.Clear();
    }
}
