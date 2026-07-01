using System.Xml.Schema;
using UnityEditor;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class fishIconSpawner : MonoBehaviour
{
    public GameObject button;
    public Transform inventoryPanelTransform;
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private float xind;
    [SerializeField] private float yind;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        xind = -120;
        yind = 11;
        buttonScript buttonscript = button.GetComponent<buttonScript>();
        foreach (string fish in buttonscript.fishInInventory)
        {
            Instantiate(iconPrefab, inventoryPanelTransform);
            RectTransform iconrect = iconPrefab.GetComponent<RectTransform>();
            iconrect.anchorMin = new Vector2(0.5f, 0.5f);
            iconrect.anchorMax = new Vector2(0.5f, 0.5f);
            iconrect.pivot = new Vector2(0.5f, 0.5f);
            iconrect.anchoredPosition = new Vector3(xind, yind, 0);
            xind += 47;
            if (xind >= 157)
            {
                yind -= 8.5f;
                xind = -120;
            }
            if (iconrect.anchoredPosition.x == xind && iconrect.anchoredPosition.y == yind)
            {
                Debug.Log("proper generation");
            }
            Debug.Log(iconPrefab.transform.position);
        }

    }
    private void OnDisable()
    {

    }
}