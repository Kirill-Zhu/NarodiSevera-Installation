using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public float PageScrollSPeed { get { return _pageScrollSpeed; } }
    public float SleepModeSpeed { get { return _sleepModeSpeed; } }
    [SerializeField] private float _pageScrollSpeed=1;
    [SerializeField] private float _sleepModeSpeed=0.3f;
    [Inject]
    [SerializeField] private SleepModeConroller _sleepModeConroller;
    [SerializeField] private float _sleeptime=90;
    [SerializeField] private float _secToSleepMode;


    private void Start()
    {
        //QualitySettings.vSyncCount = 1;
    }
    private void Update()
    {
        UpdateSleepModeTimer();

        if (Input.GetMouseButton(0))
            GoToActiveMode();

        if (Input.touchCount > 0)
            GoToActiveMode();
        if (_secToSleepMode <=0)
            GoToSleepMode();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    private void UpdateSleepModeTimer()
    {
        if(!_sleepModeConroller.IsInSleepMode)
        _secToSleepMode -= Time.deltaTime;
    }
    private void GoToActiveMode()
    {
        _secToSleepMode = _sleeptime;
        _sleepModeConroller.SetActiveMode();
    }
    [ContextMenu("Go To sleep Mode")]
    private void GoToSleepMode()
    {
        _secToSleepMode = 0;
        _sleepModeConroller.SetSleepMode();
    }
}
