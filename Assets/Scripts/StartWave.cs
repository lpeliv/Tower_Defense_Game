using Unity.VisualScripting;
using UnityEngine;

public class StartWave : MonoBehaviour, IInteractable
{
    private WaveSpawner waveSpawner;
    
    public void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();     
    }

    public void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E) && !waveSpawner.IsSpawning && waveSpawner.enabled) 
        {
            Debug.Log("Starting new wave...");
            waveSpawner.StartNewWave();
        }
    }
}
