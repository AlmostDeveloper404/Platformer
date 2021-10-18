using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    public Gun[] guns;
    public int currentIndex;

    public AudioSource BulletsPick;

    private void Start()
    {
        SetGunByIndex(currentIndex);
    }

    public void SetGunByIndex(int index)
    {
        currentIndex = index;
        for (int i = 0; i < guns.Length; i++)
        {
            if (currentIndex==i)
            {
                guns[i].Activate();
            }
            else
            {
                guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex,int amountOfBullets)
    {
        guns[gunIndex].AddBullets(amountOfBullets);
        BulletsPick.Play();
    }
}
