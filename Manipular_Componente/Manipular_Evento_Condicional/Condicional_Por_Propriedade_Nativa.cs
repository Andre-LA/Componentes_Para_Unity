using UnityEngine;

public class Condicional_Por_Propriedade_Nativa : MonoBehaviour {
    public enum PropriedadesNativas {
        TimeScale,
    }

    [Tooltip("Componente para manipular (ele que vai cuidar das condicionais)\nO valor a ser manipulado é o valor 1")]
    public Evento_Condicional condicional;
    public PropriedadesNativas propriedade;

    public void Atualizar() {
        switch (propriedade) {
            case PropriedadesNativas.TimeScale:
                condicional.Definir_Valor_1(Time.timeScale);
                break;
            default:
                Debug.LogWarning(string.Concat("Propriedade Nativa ", propriedade.ToString(), " não suportada. Gbj: ", name));
                break;
        }
    }
}
