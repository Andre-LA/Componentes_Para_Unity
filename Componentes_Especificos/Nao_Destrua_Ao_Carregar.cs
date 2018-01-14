using UnityEngine;

namespace Componentes_Para_Unity.Componentes_Especificos {
    public class Nao_Destrua_Ao_Carregar : MonoBehaviour {
    	[Tooltip("Gameobject que não será destruido ao mudar de cena")]
    	public GameObject alvo;
    	void Start () {
    		DontDestroyOnLoad(alvo)	;
    	}
    }
}
