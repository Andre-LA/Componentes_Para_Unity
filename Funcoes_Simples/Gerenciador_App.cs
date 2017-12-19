using UnityEngine;

public class Gerenciador_App : MonoBehaviour {
	public void Fechar_Applicacao() {
		Application.Quit();
	}
   	public void Abrir_URL(string url) {
	        Application.OpenURL(url);
	}
}
