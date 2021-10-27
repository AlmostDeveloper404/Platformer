using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    #region Singleton

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("More Than one PlayerHealth!");
        }

        instance = this;
    }

    #endregion 

    public int Health;
    public int MaxHealth;

    bool isVulnerable = false;

    public AudioSource AddHealthSound;

    HealthDisplayManager _healthDisplayManager;

    public UnityEvent TakeDamageEvent;

    private void Start()
    {
        _healthDisplayManager = HealthDisplayManager.instance;
        _healthDisplayManager.Setup(MaxHealth);
        _healthDisplayManager.DisplayHealth(Health);
    }
    public void TakeDamage(int damage)
    {
        if (!isVulnerable)
        {
            Health -= damage;
            if (Health<=0)
            {
                Health = 0;
                Die();
            }
            isVulnerable = true;
            Invoke("StopBeingVulnerable",1f);
            _healthDisplayManager.DisplayHealth(Health);
            TakeDamageEvent.Invoke();
        }
    }

    public void AddHealth(int healthValue)
    {
        
        Health += healthValue;
        if (Health>MaxHealth)
        {
            Health = MaxHealth;
        }
        AddHealthSound.Play();
        _healthDisplayManager.DisplayHealth(Health);

    }

    void StopBeingVulnerable()
    {
        isVulnerable = false;
    }

    void Die()
    {
        Debug.Log("Death");
    }
}
