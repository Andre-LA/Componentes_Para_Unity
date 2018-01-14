using UnityEngine;

namespace Componentes_Para_Unity.Componentes_Especificos {
    public class Retirar_Nome_Clone : MonoBehaviour {
        void Awake () {
            // name = name.Substring (0, name.Length - 7);
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
    }
}
