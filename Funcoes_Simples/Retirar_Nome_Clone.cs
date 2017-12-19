using UnityEngine;

public class Retirar_Nome_Clone : MonoBehaviour {
    void Awake () {
        // name = name.Substring (0, name.Length - 7);
        gameObject.name = gameObject.name.Replace("(Clone)", "");
    }
}
