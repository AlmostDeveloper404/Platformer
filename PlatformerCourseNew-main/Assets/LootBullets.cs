using UnityEngine;

public class LootBullets : MonoBehaviour
{

    public int GunIndex;
    public int AmountBulletsToAdd;
    private void OnTriggerEnter(Collider other)
    {
        PlayerGuns playerGuns = other.attachedRigidbody.GetComponent<PlayerGuns>();
        if (playerGuns)
        {
            playerGuns.AddBullets(GunIndex,AmountBulletsToAdd);
            Destroy(gameObject);
        }
    }
}
