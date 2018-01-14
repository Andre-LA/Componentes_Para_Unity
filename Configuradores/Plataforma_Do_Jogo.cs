using UnityEngine;
using Componentes_Para_Unity.Enumeracoes;

namespace Componentes_Para_Unity.Configuradores {
    public class Plataforma_Do_Jogo : MonoBehaviour {
        public Plataforma plataforma;
        public static Plataforma plataforma_estatica;
        static bool inicializado = false;

        void Awake() {
            if (!inicializado) {
                plataforma_estatica = plataforma;
                inicializado = true;
            }
        }
    }
}
