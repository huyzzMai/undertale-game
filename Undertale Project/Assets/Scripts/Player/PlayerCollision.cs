using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit detected");
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

}
