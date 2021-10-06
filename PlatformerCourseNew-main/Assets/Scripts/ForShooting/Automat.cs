using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public Text BulletsAmountText;
    public int numberOfBullets;

    public PlayerGuns playerGuns;

    private void Start()
    {
        UpdateText();
    }

    public override void Shoot()
    {
        base.Shoot();
        numberOfBullets--;
        UpdateText();
        if (numberOfBullets == 0)
        {
            playerGuns.SetGunByIndex(0);
        }
    }

    private void UpdateText()
    {
        BulletsAmountText.text = "Пули: " + numberOfBullets;
    }

    public override void Activate()
    {
        base.Activate();
        BulletsAmountText.enabled = true;
    }
    public override void Deactivate()
    {
        base.Deactivate();
        BulletsAmountText.enabled = false;
    }

    public override void AddBullets(int amountToAdd)
    {
        base.AddBullets(amountToAdd);
        numberOfBullets += amountToAdd;
        UpdateText();
        playerGuns.SetGunByIndex(1);
    }
}
