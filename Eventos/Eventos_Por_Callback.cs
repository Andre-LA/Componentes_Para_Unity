using UnityEngine;
using UnityEngine.Events;

public class Eventos_Por_Callback : MonoBehaviour {
    [Tooltip("Se verdadeiro, o evento correspondente será executado")]
    public bool
        usarAwake, usarStart,                            // <-- Inicializadores
        usarUpdate, usarFixedUpdate,                     // <-- game loops
        usarOnColEnter,  usarOnColStay,  usarOnColExit,  // <-- On Colisions
        usarOnTrigEnter, usarOnTrigStay, usarOnTrigExit; // <-- On Triggers

    public UnityEvent
        awake, start,                        // <-- inicializadores
        update, fixedUpdate,                 // <-- game loops
        onColEnter,  onColStay,  onColExit,  // <-- On Colisions
        onTrigEnter, onTrigStay, onTrigExit; // <-- On Triggers

    void Awake () {
        if (usarAwake)
            awake.Invoke();
    }
    void Start() {
        if (usarStart)
            start.Invoke();
    }

    void Update() {
        if (usarUpdate)
            update.Invoke();
    }

    void FixedUpdate () {
        if (usarFixedUpdate)
            fixedUpdate.Invoke();
    }

    void OnCollisionEnter(Collision colisao) {
        if (usarOnColEnter)
            onColEnter.Invoke();
    }

    void OnCollisionStay(Collision colisao) {
        if (usarOnColStay)
            onColStay.Invoke();
    }

    void OnCollisionExit(Collision colisao) {
        if (usarOnColExit)
            onColExit.Invoke();
    }

    void OnTriggerEnter(Collider colisor) {
        if (usarOnTrigEnter)
            onTrigEnter.Invoke();
    }

    void OnTriggerStay(Collider colisor) {
        if (usarOnTrigStay)
            onTrigStay.Invoke();
    }

    void OnTriggerExit(Collider colisor) {
        if (usarOnTrigExit)
            onTrigExit.Invoke();
    }

    void OnCollisionEnter2D(Collision2D colisao) {
        if (usarOnColEnter)
            onColEnter.Invoke();
    }

    void OnCollisionStay2D(Collision2D colisao) {
        if (usarOnColStay)
            onColStay.Invoke();
    }

    void OnCollisionExit2D(Collision2D colisao) {
        if (usarOnColExit)
            onColExit.Invoke();
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        if (usarOnTrigEnter)
            onTrigEnter.Invoke();
    }

    void OnTriggerStay2D(Collider2D colisor) {
        if (usarOnTrigStay)
            onTrigStay.Invoke();
    }

    void OnTriggerExit2D(Collider2D colisor) {
        if (usarOnTrigExit)
            onTrigExit.Invoke();
    }
}