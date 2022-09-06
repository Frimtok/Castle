using UnityEngine;
using Zenject;

public class TranslationInstaller : MonoInstaller
{
    [SerializeField] private Translation _translation;
    [SerializeField] private Transform _transform;
    public override void InstallBindings()
    {
        var translationInstaller = Container.InstantiatePrefabForComponent<Translation>(_translation,_transform.position,Quaternion.identity,null);
        Container.Bind<Translation>().FromInstance(_translation).AsSingle().NonLazy();
    }
}