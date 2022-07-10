using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit detected");
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = transform.position;
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }

}
