using UnityEngine;

[CreateAssetMenu(fileName = "BootData", menuName = "Boot/BootData")]
public class BootData : ScriptableObject
{
    [SerializeField] private ManagerBase[] _managers;
    public ManagerBase[] Managers => _managers;
}
