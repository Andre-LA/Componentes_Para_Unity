using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Gerenciador_Cenas : MonoBehaviour {
	public UnityEvent antes_de_abrir;

	public void Abre_Cena(string nome_cena) {
		antes_de_abrir.Invoke();
		SceneManager.LoadScene(nome_cena);
	}
}
