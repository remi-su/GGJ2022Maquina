using UnityEngine;

public class ShakeCamara : MonoBehaviour
{

    public static ShakeCamara instance;
    public Animator anim;
    
    public void CamShake()
    {
        anim.SetTrigger("Shake");
    }
}
