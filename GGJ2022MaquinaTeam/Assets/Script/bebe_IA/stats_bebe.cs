using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats_bebe : MonoBehaviour
{
    public int vida_bebe;
    public GameObject EffectToDie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida_bebe <= 0)
        {
            Instantiate(EffectToDie, transform.position, Quaternion.identity);
            FindObjectOfType<ShakeCamara>().CamShake();
            destroy();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            takedamage(5);
        }
    }
    public void takedamage(int damage)
    {
        vida_bebe = vida_bebe - damage;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
