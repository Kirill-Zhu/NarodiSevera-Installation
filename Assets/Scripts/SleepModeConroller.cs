using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class SleepModeConroller : MonoBehaviour
{
    public bool IsInSleepMode { get { return _isInSleepMode; } }
    [SerializeField] private GameObject _sleepModeScreen;
    [Inject]
    [SerializeField] private PageController _pageController;
    [Inject]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private bool _isInSleepMode;
    private CanvasGroup _canvasGroup;
    private void Start()
    {
        SetComponets();
        GetComponents();
    }
  
    public void SetSleepMode()
    {
        if(!IsInSleepMode)
        {
            _isInSleepMode = true;
            StartCoroutine(SetSleepModeCourotine());
        }
           
    }
    private IEnumerator SetSleepModeCourotine()
    {
        

        if (_canvasGroup.alpha < 1&&_isInSleepMode)
        {
          
            yield return new WaitForFixedUpdate();
            
            _canvasGroup.alpha += Time.fixedDeltaTime*_gameManager.SleepModeSpeed;
           
            StartCoroutine(SetSleepModeCourotine());
        }
        else
            _pageController.GoHomePage();



    }
    public void SetActiveMode()
    {
        _canvasGroup.alpha = 0;
        _isInSleepMode = false;
      
            
    }
    private void GetComponents()
    {
        _canvasGroup = _sleepModeScreen.GetComponent<CanvasGroup>();
    }
    private void SetComponets()
    {
        if (!_sleepModeScreen.GetComponent<CanvasGroup>())
            _sleepModeScreen.AddComponent<CanvasGroup>();
    }
}
