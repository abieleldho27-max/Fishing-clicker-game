using UnityEngine;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour
{
    public GameObject inventorypanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInventory()
    {
        if (inventorypanel.activeInHierarchy)
        {
            inventorypanel.SetActive(false);
            Debug.Log("panelout");
        }
        else
        {
            inventorypanel.SetActive(true);
        }
    }

}
