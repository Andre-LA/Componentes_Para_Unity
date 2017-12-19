using UnityEngine;
using UnityEngine.UI;

// TODO: Renomear para Escrever_Cronometro
public class Cronometro_Para_Text : MonoBehaviour {
    public Cronometro cronometro;
    public string prefixo;
    public Text texto;
    public string sufixo;
    public Medidas_De_Tempo qualTempoUsar = Medidas_De_Tempo.segundo;

    public void Atualizar_Texto() {
        switch (qualTempoUsar) {
            case Medidas_De_Tempo.segundo:
                texto.text = string.Concat(prefixo, cronometro.segundos.ToString(), sufixo);
                break;
            case Medidas_De_Tempo.minuto:
                texto.text = string.Concat(prefixo, cronometro.minutos.ToString(), sufixo);
                break;
            case Medidas_De_Tempo.hora:
                texto.text = string.Concat(prefixo, cronometro.horas.ToString(), sufixo);
                break;
            default:
                Debug.LogError("Erro: Essa medida de tempo não é suportada pelo Cronometro");
                break;
        }
    }

    public void Definir_Texto(string def) {
        texto.text = def;
    }

    #if UNITY_EDITOR
    bool Testar_Qual_Tempo_Usar() {
        return qualTempoUsar == Medidas_De_Tempo.segundo
                                || qualTempoUsar == Medidas_De_Tempo.minuto
                                || qualTempoUsar == Medidas_De_Tempo.hora;
    }

    void OnValidate() {
        // testar qual tempo usar
            Debug.Assert(Testar_Qual_Tempo_Usar(), "qualTempoUsar precisa ser Segundo, Minuto ou Hora");
    }
    #endif
}
