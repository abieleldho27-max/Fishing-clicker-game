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
    public List<string> fishSpecies = new List<string> { "salmon", "shark", "kraken" };
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
        int fishind = Random.Range(0, 3);
        counter.text = fishSpecies[fishind].ToString();
        fishInInventory.Add(fishSpecies[fishind]);
        fishing = false;

    }
}
