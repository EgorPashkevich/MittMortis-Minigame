using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public static GameInitializer Instance { get; private set; }
    [SerializeField] Conductor conductor;

    void Awake() { if (Instance != null) Destroy(gameObject); else Instance = this; }

    public void StartRound()
    {
        conductor.StartRun();
    }
}
