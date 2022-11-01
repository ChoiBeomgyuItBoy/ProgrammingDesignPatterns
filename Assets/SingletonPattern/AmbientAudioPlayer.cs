using UnityEngine;

public class AmbientAudioPlayer 
{
    private static AmbientAudioPlayer instance = null;

    private AmbientAudioPlayer() { }

    public static AmbientAudioPlayer GetInstance()
    {
        if(instance == null) 
        {
            instance = new AmbientAudioPlayer();
        }

        return instance;
    }

    public void FadeNewMusic(AudioClip clip)
    {
        //...
    }
}
