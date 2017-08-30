using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girar : MonoBehaviour {
	[Tooltip("Transform a sofrer rotação")]
	public Transform alvo;
	[Tooltip("Velocidade sobre do eixo")]
	public float velocidadeX, velocidadeY, velocidadeZ;
	[Tooltip("Relatividade, se deve girar nos eixos locais ou globais")]
	public Space relativoAo;
	[Tooltip("Se verdadeiro, a escala de tempo não interferirá na velocidade")]
	public bool independenteDeTimeScale;

	void Update() {
		Aplicar_Giro();
	}
	public void Aplicar_Giro() {
		float dt = independenteDeTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;
		alvo.Rotate(velocidadeX * dt, velocidadeY * dt, velocidadeZ * dt, relativoAo);
	}

	public void Definir_Alvo_Por_Nome(string nome) {
		alvo = GameObject.Find(nome).transform;
	}
	public void Definir_Alvo_Por_Etiqueta(string etiqueta) {
		alvo = GameObject.FindWithTag(etiqueta).transform;
	}
}
