using UnityEngine;
using UnityEngine.Events;
using Componentes_Para_Unity;

// TODO: Apenas o Executar Especifico é realmente necessário, mesmo p/ eventos, então tire o resto no próx projeto
namespace Componentes_Para_Unity.Componentes_De_Eventos {
    public class Eventos_Ordenados : MonoBehaviour {
        [Tooltip("Indice do evento, se tiver fora dos limites não será executada")]
        public int indice;
        [Tooltip("Torna o indíce cíclico, ou seja, se incrementar o indíce e passar do limite, ele volta ao inicio, e vice versa")]
        public bool indiceCiclico;
        public UnityEvent aoChamar,  depoisDeChamar;
        public UnityEvent[] eventos;

        public void Executar() {
            Executar_Especifico(indice);
        }

        public void Executar_Especifico(int i) {
            if (i < eventos.Length) {
                aoChamar.Invoke();
                eventos[i].Invoke();
                depoisDeChamar.Invoke();
            } else {
                string mensagem = string.Concat("Indice \'", i.ToString(), "\' está fora dos limites (", eventos.Length.ToString(), ")");
                Debug.LogWarning(mensagem);
            }
        }

        public void Definir_Indice(int def) {
            indice = def;
        }
        public void Incrementar_Indice(int inc) {
            indice = Funcoes_De_Apoio.Incrementa_Indice(indice, inc, eventos.Length, indiceCiclico);
        }
    }
}
