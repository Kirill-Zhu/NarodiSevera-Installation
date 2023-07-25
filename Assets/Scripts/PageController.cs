using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    [SerializeField] private GameObject _homePage;
    [SerializeField] private GameObject _bukvarEducivscogoPAge;
    [SerializeField] private List<GameObject> _aciveRejimePages;
    [SerializeField] private List<GameObject> _saamWordPagess;
    [SerializeField] private List<GameObject> _zaimstvovannieSlovaPages;
    [SerializeField] private List<GameObject> _veselieIstoriiPages;
    [SerializeField] private List<GameObject> _novayaZhiznPages;

  

    public void ActiveRegimeGoToPage(int index)
    {
        CloseAllPages();
        _aciveRejimePages[index].SetActive(true);
    }
    public void SaamskieSlovGoToPage(int index)
    {
        
        if(index<_saamWordPagess.Count&&index>=0)
        {
            CloseAllPages();
            _saamWordPagess[index].SetActive(true);
        }

    }
    public void ZaimsvovannieSloveGoPage(int index)
    {
        if (index < _zaimstvovannieSlovaPages.Count && index >= 0)
        {
            CloseAllPages();
            _zaimstvovannieSlovaPages[index].SetActive(true);
        }

    }
     public void GoHomePage()
    {
        CloseAllPages();
        _homePage.SetActive(true);
    }
    public void GoBukvarPage()
    {
        CloseAllPages();
        _bukvarEducivscogoPAge.SetActive(true);

    }
    private void CloseAllPages()
    {
        _bukvarEducivscogoPAge.SetActive(false);
        _homePage.SetActive(false);
        foreach (var page in _aciveRejimePages)
            page.SetActive(false);
        foreach (var page in _saamWordPagess)
            page.SetActive(false);
        foreach (var page in _zaimstvovannieSlovaPages)
            page.SetActive(false);
        //foreach (var page in _veselieIstoriiPages)
        //    page.SetActive(false);
        //foreach (var page in _novayaZhiznPages)
        //    page.SetActive(false);

    }

}
