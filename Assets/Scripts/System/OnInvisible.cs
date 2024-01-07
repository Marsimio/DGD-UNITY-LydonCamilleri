using UnityEngine;

public class CollisionDelete : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

}