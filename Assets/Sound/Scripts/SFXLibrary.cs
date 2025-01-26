using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLibrary : MonoBehaviour
{
    [SerializeField] private SFXGroup[] sfxGroups;
    private Dictionary<string, List<AudioClip>> soundDict;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        InitializeDictionary();

    }

    private void InitializeDictionary()
    {
        soundDict = new Dictionary<string, List<AudioClip>>();
        foreach (SFXGroup sfxGroup in sfxGroups)
        {
            soundDict[sfxGroup.name] = sfxGroup.audioClips;
        }
    }

    public AudioClip GetRandomClip(string name)
    {
        if (soundDict.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundDict[name];
            if (audioClips.Count > 0)
            {
                return audioClips[Random.Range(0, audioClips.Count)];
            }
        }

        return null;
    }
}

[System.Serializable]
public struct SFXGroup
{
    public string name;
    public List<AudioClip> audioClips;
}
