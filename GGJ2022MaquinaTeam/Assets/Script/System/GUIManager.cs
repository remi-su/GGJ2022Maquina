using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public GameObject lifeBar;
    public GameObject manaBar;

    private void Update()
    {
        string tagPlayer = FindObjectOfType<ChangeCharacter>().tagNextPlayer;
        setLife(tagPlayer);

        if (tagPlayer == "Player")
        {
            setWeaponLife(tagPlayer);
        } else
        {
            setMana(tagPlayer);
        }
    }

    private void setLife(string tagPlayer)
    {
        GameObject player = GameObject.FindGameObjectWithTag(tagPlayer);

        if (player == null)
        {
            return;
        }

        float life = player.GetComponent<CharacterController2D>().life;
        float maxLife = player.GetComponent<CharacterController2D>().vida_maxima;
        SetValueLifeBar(life, maxLife);
    }

    private void setMana(string tagPlayer)
    {
        GameObject player = GameObject.FindGameObjectWithTag(tagPlayer);

        if (player == null)
        {
            return;
        }

        float mana = player.GetComponent<CharacterController2D>().mana;
        float maxMana = player.GetComponent<CharacterController2D>().mana_maxima;
        SerValueManaBar(mana, maxMana);
    }

    private void setWeaponLife(string tagPlayer)
    {
        GameObject player = GameObject.FindGameObjectWithTag(tagPlayer);

        if (player == null)
        {
            return;
        }

        GameObject weaponDefault = player.GetComponent<CharacterController2D>().weaponManager;
        float lifeWeapon = weaponDefault.GetComponent<WeaponDefaultController>().getLifeActualWeapon();
        SerValueManaBar(lifeWeapon, 100);
    }


    private void SetValueLifeBar(float actualValue, float maxValue)
    {
        float life = (actualValue / maxValue);
        lifeBar.GetComponent<Image>().fillAmount = life;
    }

    private void SerValueManaBar(float actualValue, float maxValue)
    {
        float mana = (actualValue / maxValue);
        manaBar.GetComponent<Image>().fillAmount = mana;
    }

}
