using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
[RequireComponent(typeof(CanvasGroup))]
public class PageController : MonoBehaviour
{   [Inject]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _homePage;
    [SerializeField] private GameObject _bukvarEducivscogoPAge;
    [SerializeField] private List<GameObject> _aciveRejimePages;
    [SerializeField] private List<GameObject> _saamWordPagess;
    [SerializeField] private List<GameObject> _zaimstvovannieSlovaPages;
    [SerializeField] private List<GameObject> _veselieIstoriiPages;
    [SerializeField] private List<GameObject> _novayaZhiznPages;
    [SerializeField] private int _taskDelayMilisec = 1000;
    private CanvasGroup _canvasGroup;
    private Coroutine coroutine;
    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public async void ActiveRegimeGoToPage(int index)
    {
        if (coroutine != null)
            return;
        CloseAllPages();

        await Task.Delay(_taskDelayMilisec);

        Debug.Log("Active regime go void");
        _aciveRejimePages[index].SetActive(true);
        StartCoroutine(FadeIn());          
    }
    public async void SaamskieSlovGoToPage(int index)
    {
        if (coroutine != null)
            return;

        if (index<_saamWordPagess.Count&&index>=0)
        {
            CloseAllPages();
            await Task.Delay(_taskDelayMilisec);
            _saamWordPagess[index].SetActive(true);
            StartCoroutine(FadeIn());
        }

    }
    public async void ZaimsvovannieSloveGoPage(int index)
    {
        if (coroutine != null)
            return;
        if (index < _zaimstvovannieSlovaPages.Count && index >= 0)
        {
            CloseAllPages();
            await Task.Delay(_taskDelayMilisec);
            _zaimstvovannieSlovaPages[index].SetActive(true);
            StartCoroutine(FadeIn());
        }

    }
    public async void VeselieIstoriiGoToPage(int index)
    {
        if (coroutine != null)
            return;

        if (index < _veselieIstoriiPages.Count && index >= 0)
        {
            CloseAllPages();
            await Task.Delay(_taskDelayMilisec);
            _veselieIstoriiPages[index].SetActive(true);
            StartCoroutine(FadeIn());
        }

    }
    public async void NovayaZhiznGoToPage(int index)
    {
        if (coroutine != null)
            return;

        if (index < _novayaZhiznPages.Count && index >= 0)
        {
            CloseAllPages();
            await Task.Delay(_taskDelayMilisec);
            _novayaZhiznPages[index].SetActive(true);
            StartCoroutine(FadeIn());
        }
    }
    public async void GoHomePage()
    {
        if (coroutine != null)
            return;
        CloseAllPages();
        await Task.Delay(_taskDelayMilisec);
        _homePage.SetActive(true);
        StartCoroutine(FadeIn());
    }
    public async void GoBukvarPage()
    {
        if (coroutine != null)
            return;

        CloseAllPages();
        await Task.Delay(_taskDelayMilisec);
        _bukvarEducivscogoPAge.SetActive(true);
        StartCoroutine(FadeIn());

    }
    private async void CloseAllPages()
    {
        
        StartCoroutine(FadeOut());
        await Task.Delay(400);             
        _canvasGroup.alpha = 0;
       
        
        _bukvarEducivscogoPAge.SetActive(false);
        _homePage.SetActive(false);
        foreach (var page in _aciveRejimePages)
            page.SetActive(false);
        foreach (var page in _saamWordPagess)
            page.SetActive(false);
        foreach (var page in _zaimstvovannieSlovaPages)
            page.SetActive(false);
        foreach (var page in _veselieIstoriiPages)
            page.SetActive(false);
        foreach (var page in _novayaZhiznPages)
            page.SetActive(false);

    }
    IEnumerator FadeOut()
    {
        if (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.fixedDeltaTime * _gameManager.PageScrollSPeed;
            yield return new WaitForFixedUpdate();
            Debug.Log("Fade out");
            coroutine = StartCoroutine(FadeOut());
        }
        else
        {
            StopCoroutine(coroutine);
            coroutine = null;

        }
            
    }
    IEnumerator FadeIn()
    {

        if (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += Time.fixedDeltaTime * _gameManager.PageScrollSPeed;
            yield return new WaitForFixedUpdate();
            Debug.Log("Fade In");
            coroutine = StartCoroutine(FadeIn());
        }
        else
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
            
    }
}
