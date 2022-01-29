
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 limiteY;
    public Vector2 limiteX;
    private Transform targetToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeterminateTarget();

        if (targetToFollow != null)
        {
            FollorPlayer();
        }
        
    }

    private void FollorPlayer()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, limiteX.x, limiteX.y),
            Mathf.Clamp(targetToFollow.position.y, limiteY.x, limiteY.y),
            -10
            );
    }

    private void DeterminateTarget()
    {
        string target = FindObjectOfType<ChangeCharacter>().tagNextPlayer;
        targetToFollow = GameObject.FindGameObjectWithTag(target).transform;
    }
}
