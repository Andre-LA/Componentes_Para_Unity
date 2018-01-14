using UnityEngine;

namespace Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao {
    public class Eventos_String : MonoBehaviour{
        public Evento_String evento;

        public void Acionar(string arg) {
            evento.Invoke(arg);
        }
    }
}
