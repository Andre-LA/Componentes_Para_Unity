using UnityEngine;
using UnityEngine.Events;
using Componentes_Para_Unity.Configuradores;
using Componentes_Para_Unity.Enumeracoes;

namespace Componentes_Para_Unity.Componentes_De_Eventos {
    public class Evento_Por_Plataforma : MonoBehaviour {
        public UnityEvent pc, console, mobile, vr;

        public void Executa_Plataforma() {
            switch(Plataforma_Do_Jogo.plataforma_estatica) {
                case Plataforma.PC:
                    pc.Invoke();
                    break;
                case Plataforma.Console:
                    console.Invoke();
                    break;
                case Plataforma.Mobile:
                    mobile.Invoke();
                    break;
                case Plataforma.VR:
                    vr.Invoke();
                    break;
                default:
                    Debug.LogWarning("Plataforma não suportada");
                    break;
            }
        }
    }
}
