using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.EventSystems;
public class buttonScript : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{

    public long fishcnt;
    public TMP_Text counter;
    public float timer = 2;
    public GameObject Gauge;
    public GameObject Bar;
    

   [SerializeField] bool fishing = false;
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
        Gauge.SetActive(true);
        Bar.SetActive(true);
    }
    public void OnPointerUp(PointerEventData eventdata)
    {
        Debug.Log("UP");
        Gauge.SetActive(false);
        Bar.SetActive(false);
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
        fishcnt += 1;
        counter.text = fishcnt.ToString();
        fishing = false;

    }
}
