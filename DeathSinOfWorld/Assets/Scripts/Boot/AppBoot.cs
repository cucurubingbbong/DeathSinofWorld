using UnityEngine;
using UnityEngine.SceneManagement;

public class AppBoot : MonoBehaviour
{
    [Header("초기화 여부")]
    /// 씬 이벤트 버스
    [SerializeField] private SceneEventBus sceneEventBus;
    /// <summary>
    /// 초기화할 매니저들
    /// </summary>
    [SerializeField] private BootData bootData;

    [Header("파괴되는지 여부 여부")]
    /// <summary>
    /// 전역 매니저면 DontDestroyOnLoad, 씬 매니저면 그냥 Init
    /// </summary>
    [SerializeField] private bool isDontDestroyOnLoad = true;

    [Header("씬 로드 여부")]
    [SerializeField] private string SceneName = "Title_Scene";
    [SerializeField] private bool isLoadScene = true;
    private void Awake()
    {
        // 씬 이벤트 버스 초기화
        if(sceneEventBus != null) sceneEventBus.Init();

        if (isDontDestroyOnLoad)
        {
            foreach (ManagerBase managerBase in bootData.Managers)
            {
                ManagerBase mb = Instantiate(managerBase);
                DontDestroyOnLoad(mb.gameObject);
                if(sceneEventBus != null) mb.Init(sceneEventBus.eventBus);
                else mb.Init();
            }
        }

        else
        {
            foreach (ManagerBase managerBase in bootData.Managers)
            {
                ManagerBase mb = Instantiate(managerBase);
                if(sceneEventBus != null) mb.Init(sceneEventBus.eventBus);
                else mb.Init();
            }
        }
    }

    private void Start()
    {
        if (isLoadScene)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
