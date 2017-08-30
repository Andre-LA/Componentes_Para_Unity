using UnityEngine;
using UnityEngine.UI;

public class Cronometro_Para_Text : MonoBehaviour {
    public Cronometro cronometro;
    public Text texto;
    public Medidas_De_Tempo qualTempoUsar;

    void Start() {
        if (qualTempoUsar != Medidas_De_Tempo.segundo && qualTempoUsar != Medidas_De_Tempo.minuto && qualTempoUsar != Medidas_De_Tempo.hora)
            Debug.Log("Erro: Essa medida de tempo não é suportada pelo Cronometro");
    }

    public void Atualizar_Texto() {
        switch (qualTempoUsar) {
            case Medidas_De_Tempo.segundo:
                texto.text = cronometro.segundos.ToString();
            break;
            case Medidas_De_Tempo.minuto:
                texto.text = cronometro.minutos.ToString();
            break;
            case Medidas_De_Tempo.hora:
                texto.text = cronometro.horas.ToString();
            break;
            default:
                Debug.LogError("Erro: Essa medida de tempo não é suportada pelo Cronometro");
            break;
        }
    }
}