using UnityEngine;

public class HealLifeController : MonoBehaviour
{

    [SerializeField] float healAmount = 30;
    // Start is called before the first frame update
    
    public float getHeal()
    {
        return healAmount;
    }
}
