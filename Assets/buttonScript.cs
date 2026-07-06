using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using NUnit.Framework;
public class buttonScript : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{

    public long fishcnt;
    public TMP_Text counter;
    public float timer = 2;
    public GameObject Gauge;
    public GameObject Bar;
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
        yield return new WaitForSeconds(coroutinetimer);
        Debug.Log(coroutinetimer);
        Gauge.SetActive(false);
        Bar.SetActive(false);
        int listnmb = Random.Range(0, 626);
        if (listnmb is < 500 && listnmb is >= 1)
        {
            int fishind = Random.Range(1, cmmnfishSpecies.Count);
            counter.text = cmmnfishSpecies[fishind].ToString();
            fishInInventory.Add(cmmnfishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        else if (listnmb is < 600 && listnmb is >= 500)
        {
            int fishind = Random.Range(1, rarefishSpecies.Count);
            counter.text = rarefishSpecies[fishind].ToString();
            fishInInventory.Add(rarefishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        else if (listnmb is < 625 && listnmb is >= 600)
        {
            int fishind = Random.Range(1, epicfishSpecies.Count);
            counter.text = epicfishSpecies[fishind].ToString();
            fishInInventory.Add(epicfishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        else if (listnmb is < 626 && listnmb is >= 625)
        {
            int fishind = Random.Range(1, mythfishSpecies.Count);
            counter.text = mythfishSpecies[fishind].ToString();
            fishInInventory.Add(mythfishSpecies[fishind]);
            fishing = false;
            Debug.Log(listnmb);
        }
        

    }
}
