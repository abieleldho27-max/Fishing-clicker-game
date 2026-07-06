using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputManagerEntry;

public class fishIconSpawner : MonoBehaviour
{
    public GameObject button;
    public Transform inventoryPanelTransform;
    [SerializeField] private Button iconPrefab;
    [SerializeField] static Sprite salmonInvIcon, troutInvIcon, mahimahiInvIcon, mackeralInvIcon, codInvIcon, tarponInvIcon, permitInvIcon, lionfishInvIcon, bullsharkInvIcon, swordfishInvIcon, krakenInvIcon;
    public List<Sprite> cmmnInvIcon = new List<Sprite> { salmonInvIcon, troutInvIcon, mahimahiInvIcon, mackeralInvIcon, codInvIcon };
    public List<Sprite> rareInvIcon = new List<Sprite> { tarponInvIcon, permitInvIcon, lionfishInvIcon };
    public List<Sprite> epicInvIcon = new List<Sprite> { bullsharkInvIcon, swordfishInvIcon };
    public List<Sprite> mythInvIcon = new List<Sprite> { krakenInvIcon };
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
        for (int i = 0; i < buttonscript.fishInInventory.Count; i++)
        {
            Instantiate(iconPrefab, inventoryPanelTransform);
            RectTransform iconrect = iconPrefab.GetComponent<RectTransform>();
            if (buttonscript.cmmnfishSpecies.IndexOf(buttonscript.fishInInventory[i]) >= 0)
            {
                iconPrefab.image.sprite = cmmnInvIcon[buttonscript.cmmnfishSpecies.IndexOf(buttonscript.fishInInventory[i])];
            }
            else if (buttonscript.rarefishSpecies.IndexOf(buttonscript.fishInInventory[i]) >= 0)
            {
                iconPrefab.image.sprite = rareInvIcon[buttonscript.rarefishSpecies.IndexOf(buttonscript.fishInInventory[i])];
            }
            else if (buttonscript.epicfishSpecies.IndexOf(buttonscript.fishInInventory[i]) >= 0)
            {
                iconPrefab.image.sprite = epicInvIcon[buttonscript.epicfishSpecies.IndexOf(buttonscript.fishInInventory[i])];
            }
            else if (buttonscript.mythfishSpecies.IndexOf(buttonscript.fishInInventory[i]) >= 0)
            {
                iconPrefab.image.sprite = mythInvIcon[buttonscript.mythfishSpecies.IndexOf(buttonscript.fishInInventory[i])];
            }
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