using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Cronometro : MonoBehaviour {
	public int segundos, minutos, horas;
	public bool contarMinutos, contarHoras;
	public bool comecarCronometrando;

	public UnityEvent aoIncrementarSegundo, aoIncrementarMinuto, aoIncrementarHora;

	IEnumerator rotina;
	void Start() {
		rotina = Cronometrar();
		if (comecarCronometrando)
			StartCoroutine(rotina);
	}

	public void Iniciar_Cronometro() {
		StartCoroutine(rotina);
	}

	public void Parar_Cronometro() {
		StopCoroutine(rotina);
	}

	public void Definir_Segundos(int definicao) {
		segundos = definicao;
	}

	public void Definir_Minutos(int definicao) {
		minutos = definicao;
	}

	public void Definir_Horas(int definicao) {
		horas = definicao;
	}

	IEnumerator Cronometrar() {
		while (true) {
			yield return new WaitForSeconds(1f);
			segundos++;
			aoIncrementarSegundo.Invoke();
			
			if (segundos == 60 && contarMinutos) {
				segundos = 0;
				minutos++;
				aoIncrementarMinuto.Invoke();

				if (minutos == 60 && contarHoras) {
					minutos = 0;
					horas++;
					aoIncrementarHora.Invoke();
				}
			}
		}
	}
}
