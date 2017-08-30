using UnityEngine;
using UnityEngine.Events;

public class Evento_Pelo_Eixo : MonoBehaviour {
    [Header("Condicional")]
    [Tooltip("Eixo para ser usado")]
    public string eixo;
    [Tooltip("Condição a ser usada")]
    public Condicoes condicaoParaAtivar;
    [Tooltip("Comparação, para poder fazer a checagem da condição anterior")]
    public float comparacao;
    [Header("Eventos")]
    public UnityEvent entrouNaCondicao;
    public UnityEvent saiuDaCondicao;
    bool acionado;
    
    void Update() {
        bool acionamento = Faz_Comparacao();
        if (acionamento) {
            if (!acionado) {
                acionado = true;
                entrouNaCondicao.Invoke();
            }
        } else if (acionado) {
            acionado = false;
            saiuDaCondicao.Invoke();
        }
    }

    bool Faz_Comparacao() {
        bool resultado = false;
        float eixo_resultado = Input.GetAxisRaw(eixo);
        
        switch (condicaoParaAtivar) {
            case Condicoes.igualA:
                if (eixo_resultado == comparacao)
                    resultado = true;
            break;
            case Condicoes.diferente:
                if (eixo_resultado != comparacao)
                    resultado = true;
            break;
            case Condicoes.maiorOuIgualAQue:
                if (eixo_resultado >= comparacao)
                    resultado = true;
            break;
            case Condicoes.maiorQue:
                if (eixo_resultado > comparacao)
                    resultado = true;
            break;
            case Condicoes.menorOuIgualAQue:
                if (eixo_resultado <= comparacao)
                    resultado = true;
            break;
            case Condicoes.menorQue:
                if (eixo_resultado < comparacao)
                    resultado = true;
            break;
        }

        return resultado;
    }
}