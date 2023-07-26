using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneMonoInstaller : MonoInstaller 
{
    [SerializeField] private PageController _pageController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SleepModeConroller _sleepModeConroller;

    public override void InstallBindings()
    {
        Container.BindInstance<PageController>(_pageController);
        Container.BindInstance<GameManager>(_gameManager);
        Container.BindInstance<SleepModeConroller>(_sleepModeConroller);
    }
}
