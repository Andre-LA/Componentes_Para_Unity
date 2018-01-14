using UnityEngine;
using UnityEngine.Events;

namespace Componentes_Para_Unity {
    public class Auto_Desativador : MonoBehaviour {
    	[Tooltip("Gameobject que será desativado/ativado")]
    	public GameObject alvo;
    	public UnityEvent aoDefinirAtivacao;

    	public void Definir_Alvo (GameObject def) {
    		alvo = def;
    	}

    	public void Definir_Alvo_Por_Nome (string nome) {
    		alvo = GameObject.Find(nome);
    	}

    	public void Definir_Alvo_Por_Etiqueta (string etiqueta) {
    		alvo = GameObject.FindWithTag(etiqueta);
    	}

    	public void Definir_Ativacao (bool def) {
            aoDefinirAtivacao.Invoke();
    		alvo.SetActive(def);
    	}
    }
}
