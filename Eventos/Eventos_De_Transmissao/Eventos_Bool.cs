using UnityEngine;

namespace Componentes_Para_Unity.Componentes_De_Eventos.Eventos_De_Transmissao {
    public class Eventos_Bool : MonoBehaviour{
        public Evento_Bool evento;

        public void Acionar(bool arg) {
            evento.Invoke(arg);
        }
    }
}
