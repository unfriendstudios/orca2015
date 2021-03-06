                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         using UnityEngine;
using System.Collections;

public class Master : MonoBehaviour {
	
	private static Master _instance;
	
	public static Master instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<Master>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
	
	
	
	public bool usePedometer = true;
	public bool useVR = true;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		ToggleText[] menus = GameObject.FindObjectsOfType<ToggleText>();
		for (int i = 0; i < menus.Length; i++) {
			print ("setting bools");
			if (menus[i].name == "MoveText")
				menus[i].SetState(usePedometer);
			if (menus[i].name == "VRText")
				menus[i].SetState(useVR);
		}
	}
	
	public void ToggleMovement() {
		usePedometer = !usePedometer;
		SetSettings();
	}
	
	public void ToggleVR() {
		useVR = !useVR;
		SetSettings();
	}
	
	public void SetSettings() {
		print ("setting");
		GameObject VR = GameObject.FindObjectOfType<Cardboard>().gameObject;
		VR.GetComponent<Cardboard>().VRModeEnabled = useVR;
		MoverMaster mover = VR.GetComponent<MoverMaster>();
		if (mover != null) {
			print ("set PEDO to " + usePedometer);
			mover.usePedometer = usePedometer;
		}
	}
	
}
