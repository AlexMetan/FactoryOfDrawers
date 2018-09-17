using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sceneloading : MonoBehaviour {
	public int sceneID;
	public Image loading;

	void Start () {
		StartCoroutine (AsyncLoad ());
	}
	
	IEnumerator AsyncLoad(){
		
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneID);
		while (!operation.isDone) {
			float progress = operation.progress / 0.9f;
			loading.fillAmount = progress;
			yield return null;
		}
		}

}
