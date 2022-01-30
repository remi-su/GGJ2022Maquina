using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{

    public GameObject effectoToSpawn;
    public GameObject enemyToSpawn;
    public Transform pointToSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Instantiate(effectoToSpawn, pointToSpawn.position, Quaternion.identity);
            Instantiate(enemyToSpawn, pointToSpawn.position, Quaternion.identity);
            FindObjectOfType<ShakeCamara>().CamShake();
            Destroy(gameObject);
        }
    }
}
