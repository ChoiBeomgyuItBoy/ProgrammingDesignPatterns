using UnityEngine;

public class AmbientAudioPlayerBehaviour : MonoBehaviour
{
    private static AmbientAudioPlayerBehaviour instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void FadeNewMusic(AudioClip clip)
    {
        //...
    }
}
