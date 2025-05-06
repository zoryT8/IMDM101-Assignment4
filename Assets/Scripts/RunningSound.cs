using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
    private AudioSource audioSource;
    private Transform player;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = transform.parent;
    }

    void Update()
    {
        if (player != null && player.name == "Player (Mouse)")
        {
            bool isGrounded = Mathf.Abs(player.position.y - 0.1225509f) < 0.001f;

            if (isGrounded && !PlayerController.gameOver)
            {
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
            else
            {
                if (audioSource.isPlaying)
                    audioSource.Stop();
            }
        }
    }
}
