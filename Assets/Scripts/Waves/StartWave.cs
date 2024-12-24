using UnityEngine;

public class StartWave : MonoBehaviour, IInteractable
{
    private WaveSpawner waveSpawner;
    public Animator animator;

    public void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    public void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E) && !waveSpawner.IsSpawning && waveSpawner.enabled) 
        {
            animator.SetTrigger("LeverDown");
            waveSpawner.StartNewWave();
        }
    }
}
