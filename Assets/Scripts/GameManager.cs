using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] Image caughtImage;
    [SerializeField] private Image wonImage;
    [SerializeField] private float fadeDuration;
    [SerializeField] private float displayImageDuration;

    public bool isPlayerAtExit;
    public bool isPlayerCaught;
    
    [Header("Audio Clip")]
    [SerializeField] private AudioClip caughtClip;
    [SerializeField] private AudioClip wonClip;
    
    AudioSource audioSource;
    private float timer;
    private bool restartLevel;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
            Won();
        }
        else if (isPlayerCaught)
        {
            Caught();
        }
    }

    void Won()
    {
        audioSource.clip = wonClip;
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
        timer += Time.deltaTime;
        
        wonImage.color = new Color(wonImage.color.r, wonImage.color.g, wonImage.color.b, timer/fadeDuration);

        if (timer >= fadeDuration + displayImageDuration)
        {
            Debug.Log("You win");
        }
    }

    void Caught()
    {
        audioSource.clip = caughtClip;
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
        timer += Time.deltaTime;
        
        caughtImage.color = new Color(caughtImage.color.r, caughtImage.color.g, caughtImage.color.b, timer/fadeDuration);

        if (timer >= fadeDuration + displayImageDuration)
        {
            Debug.Log("You have been caught");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
