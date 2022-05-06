using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsPlayer : Singleton<SoundsPlayer>
{
    private AudioSource _source;

    public void PlaySound(AudioClip clip) => _source.PlayOneShot(clip);

    public void PlayRandomSound(AudioClip[] clips)
    {
        PlaySound(clips[Random.Range(0, clips.Length)]);
    }

    protected override void Awake()
    {
        base.Awake();
        _source = GetComponent<AudioSource>();
    }
}
