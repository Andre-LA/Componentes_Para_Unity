using UnityEngine;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_Transform {
    public class Vai_Para_Ponto_Medio : MonoBehaviour {
        [Tooltip("As referências serão obtidas através dessa etiqueta, caso vazio, a procura não será realizada")]
        public string tagDasReferencias;
        [Tooltip("Referências para obter-se o ponto médio")]
        public Transform[] referecias;

        void Start() {
            Obtem_Referencias();
        }

        void Update() {
            // novo pos_final (0, 0, 0)
            Vector3 pos_final = new Vector3(0, 0, 0);

            // soma sua posição com todas as referencias
            for (int i = 0; i < referecias.Length; i++)
                pos_final += referecias[i].position;

            // faz a média
            pos_final /= referecias.Length;

            // aplica média
            transform.position = pos_final;
        }

        // se o campo tag não for vazia, ele obtem todos os objetos com essa tag
        public void Obtem_Referencias() {
            if (tagDasReferencias != "") {
                GameObject[] gbjs_encontrados = GameObject.FindGameObjectsWithTag(tagDasReferencias);
                referecias = new Transform[gbjs_encontrados.Length];
                for (int i = 0; i < referecias.Length; i++)
                    referecias[i] = gbjs_encontrados[i].GetComponent<Transform>();
            }
        }

        public void Definir_Tag_Das_Referencias(string nova_etiqueta) {
            tagDasReferencias = nova_etiqueta;
        }
    }
}
