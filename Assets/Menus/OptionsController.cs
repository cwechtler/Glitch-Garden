using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	[SerializeField] private Slider volumeSlider;
	[SerializeField] private Slider difficultySlider;
	[SerializeField] private LevelManager levelManager;
	
	private MusicManager musicManager;
	
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if (PlayerPrefs.HasKey ("master_volume")){
			volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		}else {
			volumeSlider.value = 0.5f;
		}
		
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update () {
		musicManager.ChangeVolume (volumeSlider.value);
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadLevel ("Start Menu");
	}
	
	public void SetDefaults(){
		volumeSlider.value = 0.5f;
		difficultySlider.value = 1f;
	}
}
