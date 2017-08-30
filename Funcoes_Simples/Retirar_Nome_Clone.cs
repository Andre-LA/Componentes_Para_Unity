using UnityEngine;

/// <summary>
/// Retira o "(Clone)" no final do nome de um prefab instanciado
/// </summary>
public class Retirar_Nome_Clone : MonoBehaviour
{
    void Awake () {
        name = name.Substring (0, name.Length - 7);
    }
}
