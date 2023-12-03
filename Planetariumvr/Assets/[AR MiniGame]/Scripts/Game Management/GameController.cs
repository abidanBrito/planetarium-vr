using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game Manager acts as a master Singleton (Service Locator)
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    // Game score
    public uint Points { get; private set; }

    // Services
    [SerializeField] private PlayerManager playerManager;
    public PlayerManager PlayerManager { get { return playerManager; } private set { playerManager = value; } }
    
    [SerializeField] private AudioManager audioManager;
    public AudioManager AudioManager { get { return audioManager; } private set { audioManager = value; } }
    
    [SerializeField] private UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } private set { uiManager = value; } }

    // Extra points
    [SerializeField] private uint extraPoints = 50;
    [SerializeField] private float pointsTimer = 20f;
    private float elapsedTime = 0f;

    // Background music
    [SerializeField] private AudioClip bgMusic;

    // Monobehaviour doesn't have a constructor per se,
    // Start() or Awake() are the next best thing.
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;

        // Get service references
        PlayerManager = GetComponentInChildren<PlayerManager>();
        AudioManager = GetComponentInChildren<AudioManager>();
        UIManager = GetComponentInChildren<UIManager>();


        // NOTE(abi): keep the instance in between scenes.
        DontDestroyOnLoad(gameObject);
    }

    private void Start() => audioManager.PlayBackgroundMusic(bgMusic);

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > pointsTimer)
        {
            AddExtraPoints();
        }
    }

    private void AddExtraPoints()
    {
        Points += extraPoints;
        UIManager.UpdateScore();
        elapsedTime = 0f;
    }

    public void AddPoints(uint points)
    {
        Points += points;
        UIManager.UpdateScore();
    }
}
