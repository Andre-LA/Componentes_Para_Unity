using UnityEngine;

public class Nao_Destrua_Ao_Carregar : MonoBehaviour {
	[Tooltip("Gameobject que não será destruido ao mudar de cena")]
	public GameObject alvo;
	void Start () {
		DontDestroyOnLoad(alvo)	;
	}
}
