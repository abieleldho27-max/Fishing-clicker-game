using System;
using UnityEngine;

public class barSript : MonoBehaviour
{
    public float barlength = 2.3f;
    public float barspeed = 1f;
    public float originalx;
    public float startpos = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        originalx = transform.position.x;
        Debug.Log(transform.position.x);
    }
    private void OnEnable()
    {
        transform.position = new Vector2(startpos, transform.position.y);
    }
    // Update is called once per frame
    void Update()
    {
       if(true)
        {
            float newx = originalx + Mathf.Sin(Time.time * barspeed) * barlength;
            transform.position = new Vector2(newx, transform.position.y);
        }
    }
}
