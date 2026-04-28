using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController Playercon;
    public float playerHp = 100f;
    public Slider hpBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        hpBar.value = playerHp / 100;
    }

    public void MinusHp(float MinusValue)
    {
        playerHp -= MinusValue;
        if (playerHp <= 0)
        {
            Playercon.Die();
        }
    }


}
