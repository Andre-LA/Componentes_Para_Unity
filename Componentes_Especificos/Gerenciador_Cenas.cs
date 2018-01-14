using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Componentes_Para_Unity.Componentes_Especificos {
    public class Gerenciador_Cenas : MonoBehaviour {
    	public UnityEvent antes_de_abrir, depois_de_abrir;

    	public void Abre_Cena(string nome_cena) {
    		antes_de_abrir.Invoke();
    		SceneManager.LoadScene(nome_cena);
    	}
    	public void Adiciona_Cena(string nome_cena) {
    		antes_de_abrir.Invoke();
    		SceneManager.LoadScene(nome_cena, LoadSceneMode.Additive);
            depois_de_abrir.Invoke();
    	}
    }
}
