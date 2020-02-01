using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronScript : MonoBehaviour
{
    [SerializeField] int bubblingDelay;
    [SerializeField] Sprite[] bubblingSprites;
    FMOD.Studio.EventInstance _couldronBubble;
    FMOD.Studio.EventInstance _couldroneRumble;
    FMOD.Studio.EventInstance _couldroneAmbience;
    // Start is called before the first frame update
    void Start()
    {
        _couldronBubble = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Cauldron/_cauldronBubbling");
        _couldroneRumble = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Cauldron/_cauldronRumble");
        _couldroneAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Cauldron/_cauldronEAmbience");
        CouldroneSoundscapeON();

    }

    // Update is called once per frame
    void Update()
    {
        _couldroneAmbience.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _couldroneRumble.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        _couldronBubble.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

    }
    void CouldroneSoundscapeON()
    {
        _couldroneAmbience.start();
        _couldronBubble.start();
        _couldroneRumble.start();
    }
}
