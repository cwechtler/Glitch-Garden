using UnityEngine;

public class MusicManager : MonoBehaviour {

	[SerializeField] private AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		
	}
	void Start(){
		audioSource = GetComponent<AudioSource>();
		if (PlayerPrefs.HasKey ("master_volume")){
			audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		}else {
			audioSource.volume = 0.5f;
		}
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if(thisLevelMusic){
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			if(!audioSource.isPlaying){
				audioSource.Play();
			}
		}
	}
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}
