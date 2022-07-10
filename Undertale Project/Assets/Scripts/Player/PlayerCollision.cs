using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool GameIsEnd = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit detected");
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
        Time.timeScale = 0;
        GameIsEnd = true;
    }

}
