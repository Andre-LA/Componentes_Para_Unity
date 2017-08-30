using UnityEngine;
using UnityEngine.Events;

public class Eventos_ColTrig_Condicional_porTag : MonoBehaviour {
    [Tooltip("Se verdadeiro, essa função da Unity será executada")]
    public bool 
        usarColEnter,  usarColStay,  usarColExit,   // <-- On Colisions
        usarTrigEnter, usarTrigStay, usarTrigExit; // <-- On Triggers
    [Tooltip("Etiqueta para comparação, se a entiqueta for igual a etiqueta do objeto estrangeiro, então o evento correspondente será executado")]
    public string
        casoTagOnColEnter,  casoTagOnColStay,  casoTagOnColExit,   // <-- On Colisions
        casoTagOnTrigEnter, casoTagOnTrigStay, casoTagOnTrigExit; // <-- On Triggers

    public UnityEvent
        onColEnter,  onColStay,  onColExit,   // <-- On Colisions
        onTrigEnter, onTrigStay, onTrigExit; // <-- On Triggers

    void OnCollisionEnter(Collision colisao) {
        if (usarColEnter) {
            if (colisao.gameObject.CompareTag(casoTagOnColEnter))
                onColEnter.Invoke();
        }
    }

    void OnCollisionStay(Collision colisao) {
        if (usarColStay) {
            if (colisao.gameObject.CompareTag(casoTagOnColStay))
                onColStay.Invoke();
        }
    }

    void OnCollisionExit(Collision colisao) {
        if (usarColExit) {
            if (colisao.gameObject.CompareTag(casoTagOnColExit))
                onColExit.Invoke();
        }
    }

    void OnTriggerEnter(Collider colisor) {
        if (usarTrigEnter) {
            if (colisor.gameObject.CompareTag(casoTagOnTrigEnter))
                onTrigEnter.Invoke();
        }
    }

    void OnTriggerStay(Collider colisor) {
        if (usarTrigStay) {
            if (colisor.gameObject.CompareTag(casoTagOnTrigStay))
                onTrigStay.Invoke();
        }
    }

    void OnTriggerExit(Collider colisor) {
        if (usarTrigExit) {
            if (colisor.gameObject.CompareTag(casoTagOnTrigExit))
                onTrigExit.Invoke();
        }
    }
}