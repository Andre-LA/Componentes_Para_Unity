using UnityEngine;
using UnityEngine.Events;

namespace Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao {
    public class Eventos : MonoBehaviour {
        public UnityEvent evento;

        public void Acionar() {
            evento.Invoke();
        }
        public void Imprimir(string mensagem) {
            print (mensagem);
        }
    }

    [System.Serializable] public class Evento_Bool  : UnityEvent<bool>  {}
    [System.Serializable] public class Evento_Float : UnityEvent<float> {}
    [System.Serializable] public class Evento_Int   : UnityEvent<int>   {}
    [System.Serializable] public class Evento_String: UnityEvent<string>{}
}
