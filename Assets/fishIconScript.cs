using UnityEngine;

public class fishIconScript : MonoBehaviour
{
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
