using UnityEngine;

public class Olhar_Para : MonoBehaviour {
    [Tooltip("Transform daquele que 'olhará' para o alvo")]
    public Transform observador;
    [Tooltip("Transform daquele que o 'observador' irá apontar")]
    public Transform alvo;
    [Tooltip("valor do worldUp do LookAt")]
    public Vector3 worldUp;
    void Update() {
        observador.LookAt(alvo, worldUp);
    }
}