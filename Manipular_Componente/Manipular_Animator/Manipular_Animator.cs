using UnityEngine;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Animator {
    public class Manipular_Animator : MonoBehaviour {
        public Animator animadorAlvo;

        #region Definidores
        public void Definir_Animador (Animator def) {
            animadorAlvo = def;
        }
        public void Definir_Animador_Pelo_Nome (string nome) {
            animadorAlvo = GameObject.Find(nome).GetComponent<Animator>();
        }
        public void Definir_Animador_Pela_Etiqueta (string etiqueta) {
            animadorAlvo = GameObject.FindWithTag(etiqueta).GetComponent<Animator>();
        }
        public void Definir_Animador_Obtendo_Pelo_Gbj (GameObject gbj) {
            animadorAlvo = gbj.GetComponent<Animator>();
        }
        #endregion // Definidores

        public void Definir_Controlador_Do_Alvo(RuntimeAnimatorController def) {
            animadorAlvo.runtimeAnimatorController = def;
        }
    }
}
