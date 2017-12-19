using UnityEngine;
using UnityEngine.UI;

public class Escreve_FPS : MonoBehaviour {
	[Tooltip("Componente de texto a ter seu texto escrito")]
	public Text texto;
	[Tooltip("Texto que será incluido antes do número de fps")]
	public string prefixo;
	[Tooltip("Texto que será incluido depois do número de fps")]
	public string sufixo;
	[Tooltip("Intervalo em segundos para a atualização de texto")]
	public float intervalo;
	float ultima_atualizacao;
	
	void Start() {
		ultima_atualizacao = Time.unscaledTime;
	}

	void Update () {
		if (Time.unscaledTime - ultima_atualizacao > intervalo) {
			ultima_atualizacao = Time.unscaledTime;
			float fps = 1f / Time.smoothDeltaTime;
			texto.text = string.Concat(prefixo, fps, sufixo);
		}
	}
}
