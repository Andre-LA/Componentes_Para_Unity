using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Cronometro : MonoBehaviour {
    [Header("Relógio")]
	public int segundos;
    public int minutos, horas;

    [Header("Configurações")]
    public bool comecarCronometrando;
	public bool contarMinutos, contarHoras;

    [Tooltip("Se ativado, será verificada se o tempo contado é igual ou superior ao tempo limite.\nSe sim, o evento de limite será executada (apenas quando for atingido)")]
    public bool contarLimite;

    [Header("Limite para contagem")]
    public int limiteSegundos;
    public int limiteMinutos, limiteHoras;

    bool atingiuLimite;

    [Header("Eventos para cada caso")]
	public UnityEvent aoIncrementarSegundo;
    public UnityEvent aoIncrementarMinuto,
                      aoIncrementarHora,
                      aoAtingirLimite,
                      aoSairDoLimite;

	IEnumerator rotina;
	void Start() {
		rotina = Cronometrar();
		if (comecarCronometrando)
			StartCoroutine(rotina);
	}

	public void Iniciar_Cronometro() {
        StopCoroutine(rotina); // para não executar 2 co-rotinas ao msm tempo
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

    public void Verificar_Limite() {
        // se está contando limite e os tempos atingiu ou ultrapassou o limite e o evento de limite n foi executado
        // -> executa evento de qnd o limite é atingido
        if (contarLimite) {
            bool ultrapassou_limite = segundos     >= limiteSegundos
                                        && minutos >= limiteMinutos
                                        && horas   >= limiteHoras;

            if (!atingiuLimite && ultrapassou_limite) {
                aoAtingirLimite.Invoke();
                atingiuLimite = true;
            } else if (atingiuLimite && !ultrapassou_limite) {
                aoSairDoLimite.Invoke();
                atingiuLimite = false;
            }
        }
    }

    #region Incrementos
    public void Incrementar_Segundos(int inc) {
        segundos += inc;

        if (contarMinutos) {
            if (segundos == 60) {
                segundos = 0;
                Incrementar_Minutos(1);
            } else if (segundos == -1) {
                segundos = 59;
                Incrementar_Minutos(-1);
            }
        }

        aoIncrementarSegundo.Invoke();
        Verificar_Limite();
    }

    public void Incrementar_Minutos(int inc) {
        minutos += inc;

        if (contarHoras) {
            if (minutos == 60) {
                minutos = 0;
                Incrementar_Horas(1);
            } else if (minutos == -1) {
                minutos = 59;
                Incrementar_Horas(-1);
            }
        }

        aoIncrementarMinuto.Invoke();
        Verificar_Limite();
    }

    public void Incrementar_Horas(int inc) {
        horas += inc;
        aoIncrementarHora.Invoke();
        Verificar_Limite();
    }
    #endregion // incrementos

	IEnumerator Cronometrar() {
		while (true) {
			yield return new WaitForSeconds(1f);
            // a cada segundo Incrementa 1 segundo
            // se ultrapassar 60 segundos e os minutos estiverem sendo contados, ele já incrementa o minuto
            // o incremento dos minutos faz a mesma coisa para a hora
            Incrementar_Segundos(1);
		}
	}
}
