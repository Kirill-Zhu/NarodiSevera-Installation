using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneMonoInstaller : MonoInstaller 
{
    [SerializeField] private PageController _pageController;

    public override void InstallBindings()
    {
        Container.BindInstance<PageController>(_pageController);
    }
}
