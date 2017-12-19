using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Auto_Executor : MonoBehaviour {
    [Header("Propriedades")]
    [Tooltip("Quando verdadeiro, ele inicializará a auto-execução automaticamente (de acordo com os parâmetros abaixo)")]
    public bool executar;
    bool executando;
    [Tooltip("Se verdadeiro, o tempo de espera ocorre antes da execução, caso contrário, a espera é depois")]
    public bool esperarAntesDeExecutar;
    [Tooltip("Tempo (em segundos) de intervalo, pode ser multiplicado por Δtempo pela propriedade Multiplicar Por Delta Tempo")]
    public float intervalo;
    [Tooltip("Caso verdadeiro, o intervalo será multiplicado pelo Δtempo")]
    public bool multiplicarPorDeltaTempo;
    [Tooltip("caso verdadeiro, o Δtempo e a corrotina não são influenciadas pela escala de tempo")]
    public bool independenteDeEscalaDeTempo;

    [Header("Evento")]
    public UnityEvent cadeiaDeExecucao;

    void Start() {
        if (executar)
            Iniciar();
    }

    void Iniciar() {
        if (esperarAntesDeExecutar)
            StartCoroutine(Auto_Executar_PreEspera());
        else
            StartCoroutine(Auto_Executar_PosEspera());
        executando = true;
    }

    void Update() {
        if (executar && !executando)
            Iniciar();
        else if (!executar && executando) {
            StopAllCoroutines();
            executando = false;
        }
    }

    public void Definir_Executar(bool definicao) {
        executar = definicao;
    }

    IEnumerator Auto_Executar_PreEspera () {
        while (true) {
            if (multiplicarPorDeltaTempo) {
                if (independenteDeEscalaDeTempo)
                    yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime * intervalo);
                else
                    yield return new WaitForSeconds(Time.deltaTime * intervalo);
            }
            else {
                if (independenteDeEscalaDeTempo)
                    yield return new WaitForSecondsRealtime(intervalo);
                else
                    yield return new WaitForSeconds(intervalo);
            }
            cadeiaDeExecucao.Invoke();
        }
    }

    IEnumerator Auto_Executar_PosEspera () {
        while (true) {
            cadeiaDeExecucao.Invoke();
            if (multiplicarPorDeltaTempo) {
                if (independenteDeEscalaDeTempo)
                    yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime * intervalo);
                else
                    yield return new WaitForSeconds(Time.deltaTime * intervalo);
            }
            else {
                if (independenteDeEscalaDeTempo)
                    yield return new WaitForSecondsRealtime(intervalo);
                else
                    yield return new WaitForSeconds(intervalo);
            }
        }
    }

    #region Definicoes

    public void Incrementar_Intervalo(float incremento) {
        intervalo += incremento;
    }

    public void Multiplicar_Intervalo(float multiplicador) {
        intervalo *= multiplicador;
    }

    public void Definir_Esperar_Antes_De_Executar(bool def) {
        esperarAntesDeExecutar = def;
    }

    public void Definir_Se_Multiplica_Pelo_Delta_Tempo(bool def) {
        multiplicarPorDeltaTempo = def;
    }

    public void Definir_Se_Independente_De_Escala_De_Tempo(bool def) {
        independenteDeEscalaDeTempo = def;
    }

    #endregion
}
