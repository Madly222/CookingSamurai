using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SpawnableInstaller", menuName = "Installers/SpawnableInstaller")]
public class SpawnableInstaller : ScriptableObjectInstaller<SpawnableInstaller>
{
    public SpawnableStorage spawnableStorage;

    public override void InstallBindings()
    {
        Container.BindInstance(spawnableStorage).AsSingle();
    }
}