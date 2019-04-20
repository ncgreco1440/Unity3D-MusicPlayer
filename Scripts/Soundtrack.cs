using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public IcedCoffee.MusicLoader loader = new IcedCoffee.MusicLoader("/Music");

    void Start()
    {
        StartCoroutine(loader.LoadFilesFromDisk("Urban", this.SoundtrackLoaded));
    }

    public void SoundtrackLoaded()
    {
        Debug.Log("Soundtrack has been loaded!");
    }
}
