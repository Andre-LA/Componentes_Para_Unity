using UnityEngine;

namespace Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao {
    public class Eventos_Int : MonoBehaviour{
        public Evento_Int evento;

        public void Acionar(int arg) {
            evento.Invoke(arg);
        }
    }
}
