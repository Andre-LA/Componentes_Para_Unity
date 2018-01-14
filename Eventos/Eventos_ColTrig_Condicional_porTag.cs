using UnityEngine;
using UnityEngine.Events;

namespace Componentes_Para_Unity.Componentes_De_Eventos {
    public class Eventos_ColTrig_Condicional_porTag : MonoBehaviour {
        [Tooltip("Se verdadeiro, essa função da Unity não será interrompida")]
        public bool
            usarColEnter,  usarColStay,  usarColExit,  // <-- On Colisions
            usarTrigEnter, usarTrigStay, usarTrigExit; // <-- On Triggers
        [Tooltip("Etiqueta para comparação, se a entiqueta for igual a etiqueta do objeto estrangeiro, então o evento correspondente será executado")]
        public string
            casoTagOnColEnter,  casoTagOnColStay,  casoTagOnColExit,  // <-- On Colisions
            casoTagOnTrigEnter, casoTagOnTrigStay, casoTagOnTrigExit; // <-- On Triggers

        public UnityEvent
            onColEnter,  onColStay,  onColExit,  // <-- On Colisions
            onTrigEnter, onTrigStay, onTrigExit; // <-- On Triggers

        void OnCollisionEnter(Collision colisao) {
            if (usarColEnter)
                if (colisao.gameObject.CompareTag(casoTagOnColEnter))
                    onColEnter.Invoke();
        }

        void OnCollisionStay(Collision colisao) {
            if (usarColStay)
                if (colisao.gameObject.CompareTag(casoTagOnColStay))
                    onColStay.Invoke();
        }

        void OnCollisionExit(Collision colisao) {
            if (usarColExit) {
                if (colisao.gameObject.CompareTag(casoTagOnColExit))
                onColExit.Invoke();
            }
        }

        void OnTriggerEnter(Collider colisor) {
            if (usarTrigEnter)
                if (colisor.CompareTag(casoTagOnTrigEnter))
                    onTrigEnter.Invoke();
        }

        void OnTriggerStay(Collider colisor) {
            if (usarTrigStay)
                if (colisor.CompareTag(casoTagOnTrigStay))
                    onTrigStay.Invoke();
        }

        void OnTriggerExit(Collider colisor) {
            if (usarTrigExit)
                if (colisor.CompareTag(casoTagOnTrigExit))
                    onTrigExit.Invoke();
        }

        public void Definir_Uso_Como_Verdadeiro (string nome_da_variavel) {
            Definir_Uso(nome_da_variavel, true);
        }

        public void Definir_Uso_Como_Falso (string nome_da_variavel) {
            Definir_Uso(nome_da_variavel, false);
        }

        public void Definir_Uso(string nome_da_variavel, bool def) {
            switch(nome_da_variavel) {
                case "usarColEnter":
                    usarColEnter = def;
                    break;
                case "usarColStay":
                    usarColStay = def;
                    break;
                case "usarColExit":
                    usarColExit = def;
                    break;
                case "usarTrigEnter":
                    usarTrigEnter = def;
                    break;
                case "usarTrigStay":
                    usarTrigStay = def;
                    break;
                case "usarTrigExit":
                    usarTrigExit = def;
                    break;
            }
        }
    }
}
