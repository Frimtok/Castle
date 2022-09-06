using UnityEngine;
using Zenject;

public class PeasantsInstaller : MonoInstaller
{
    [SerializeField] private WorkerButton _workerButton;
    public override void InstallBindings()
    {
        Container.Bind<WorkerButton>().FromInstance(_workerButton).AsSingle();
        Container.QueueForInject(_workerButton);
    }
}