using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SpawnableInstaller", menuName = "Installers/SpawnableInstaller")]
public class CookingInstaller : ScriptableObjectInstaller<CookingInstaller>
{
    public CookingInstaller cookingStorage;

    public override void InstallBindings()
    {
        Container.BindInstance(cookingStorage).AsSingle();
    }
}
