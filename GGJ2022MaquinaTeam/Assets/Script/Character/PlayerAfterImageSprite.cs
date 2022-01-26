using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{

    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    private float alphaSet = 0.8f;
    private float alphaMultiplier = 0.85f;

    private Transform player;
    private Transform playerGFX;

    private SpriteRenderer SRLegs;
    private SpriteRenderer SRBody;
    private SpriteRenderer playerLegsSR;
    private SpriteRenderer playerBodySR;

    private Color color;

    private void OnEnable()
    {
        SRBody = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        SRLegs = transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerGFX = GameObject.FindGameObjectWithTag("CharacterGFX").transform;
        playerBodySR = playerGFX.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        playerLegsSR = playerGFX.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SRBody.sprite = playerBodySR.sprite;
        SRLegs.sprite = playerLegsSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f,1f,1f, alpha);
        SRBody.color = color;
        SRLegs.color = color;

        if (Time.time >= (timeActivated + activeTime))
        {
            PlayerImageAfterPool.Instance.AddToPool(gameObject);
        }
    }
}
