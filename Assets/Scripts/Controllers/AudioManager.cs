using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource music;

    public static AudioManager instace;

    private void Awake()
    {
        if (instace != null && instace != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instace = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
