using UnityEngine;
using TMPro;
using System.Collections;
public class buttonScript : MonoBehaviour
{
    public long fishcnt;
    public TMP_Text counter;
    public float timer = 2;
   [SerializeField] bool fishing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
