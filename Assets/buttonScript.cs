using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using NUnit.Framework;
using Unity.VisualScripting;
public class buttonScript : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{

    public long fishcnt;
    public TMP_Text counter;
    public float timer = 2;
    public GameObject Gauge;
    public GameObject Bar;
    private int standardRareMin = 500;
    private int standardEpicMin = 600;
    private int standardMythMin = 625;
    public int rareMin;
    public int epicMin;
    public int mythMin;

    public List<string> cmmnfishSpecies = new List<string> { "Salmon", "Trout", "Mahi Mahi", "Mackeral", "Cod" };
    public List<string> rarefishSpecies = new List<string> { "Tarpon", "Permit", "Lionfish" };
    public List<string> epicfishSpecies = new List<string> { "Bull Shark", "Swordfish" };
    public List<string> mythfishSpecies = new List<string> { "Kraken" };

    public List<string> fishInInventory;
   [SerializeField] public bool fishing = false;
    public bool barOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gauge.SetActive(false);
        Bar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventdata)
    {
        Debug.Log("down");
        barOn = true;
        Gauge.SetActive(true);
        Bar.SetActive(true);
        
    }
    public void OnPointerUp(PointerEventData eventdata)
    {
        Debug.Log("UP");
        barOn = false;

    }
    public void fish()
    {
        if (fishing == false)
        {
            StartCoroutine(gofish(timer));
            fishing = true;
        }
    }
    IEnumerator gofish(float coroutinetimer)
    {
        Transform bartransform = Bar.GetComponent<Transform>();
        float barposx = bartransform.transform.position.x;
        float barmultiplier = 1.1f - Mathf.Abs(barposx);
        if (barmultiplier < 0)
        {
            barmultiplier = 0;
        }
        rareMin = standardRareMin - (Mathf.RoundToInt(barmultiplier) * 40);
        epicMin = standardEpicMin - (Mathf.RoundToInt(barmultiplier) * 10);
        mythMin = standardMythMin - (Mathf.RoundToInt(barmultiplier));
        yield return new WaitForSeconds(coroutinetimer);
        Gauge.SetActive(false);
        Bar.SetActive(false);
        int listnmb = Random.Range(0, 626);
        if (listnmb < rareMin && listnmb >= 1)
        {
            int fishind = Random.Range(1, cmmnfishSpecies.Count);
            counter.text = cmmnfishSpecies[fishind].ToString();
            fishInInventory.Add(cmmnfishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        else if (listnmb < 600 && listnmb >= rareMin)
        {
            int fishind = Random.Range(1, rarefishSpecies.Count);
            counter.text = rarefishSpecies[fishind].ToString();
            fishInInventory.Add(rarefishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        else if (listnmb < 625 && listnmb >= epicMin)
        {
            int fishind = Random.Range(1, epicfishSpecies.Count);
            counter.text = epicfishSpecies[fishind].ToString();
            fishInInventory.Add(epicfishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        else if (listnmb < 626 && listnmb >= mythMin)
        {
            int fishind = Random.Range(1, mythfishSpecies.Count);
            counter.text = mythfishSpecies[fishind].ToString();
            fishInInventory.Add(mythfishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        

    }
}
