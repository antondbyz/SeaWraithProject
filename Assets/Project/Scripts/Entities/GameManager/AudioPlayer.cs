using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : Singleton<AudioPlayer>
{
    private AudioSource _source;

    public void PlayAudioOneShot(AudioClip clip) => _source.PlayOneShot(clip);

    public void PlayRandomAudioOneShot(AudioClip[] clips)
    {
        PlayAudioOneShot(clips[Random.Range(0, clips.Length)]);
    }

    protected override void Awake()
    {
        base.Awake();
        _source = GetComponent<AudioSource>();
    }
}
