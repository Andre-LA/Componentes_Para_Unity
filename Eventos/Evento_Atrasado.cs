using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Evento_Atrasado : MonoBehaviour {
    [Tooltip("tempo de atraso (em segundos)")]
    public float tempo;
    [Tooltip("se verdadeiro, a espera não é influenciada pela escala de tempo")]
    public bool independenteDeEscalaDeTempo;
    public UnityEvent evento;

    public void Executar() {
        StartCoroutine(CR_Executar());
    }

    public void Definir_Tempo(float def) {
        tempo = def;
    }

    public void Multiplicar_Tempo(float fator) {
        tempo *= fator;
    }

    public void Incrementar_Tempo(float incremento) {
        tempo += incremento;
    }

    public void Definir_Independencia_Pela_Escala_De_Tempo(bool def) {
        independenteDeEscalaDeTempo = def;
    }

    IEnumerator CR_Executar() {
        if (independenteDeEscalaDeTempo)
            yield return new WaitForSecondsRealtime(tempo);
        else
            yield return new WaitForSeconds(tempo);
        evento.Invoke();
    }
}
