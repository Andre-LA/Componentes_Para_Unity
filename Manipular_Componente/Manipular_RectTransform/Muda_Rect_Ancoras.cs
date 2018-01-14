using UnityEngine;

namespace Componentes_Para_Unity.Manipular_Componente.Manipular_RectTransform {
    public class Muda_Rect_Ancoras : MonoBehaviour {
        [Tooltip("RectTransform a ser manipulado")]
        public RectTransform rectTransform;
        [Tooltip("Valores das âncoras,\nas chaves x, y são para os x e y da âncora mínima\nE as chaves z e w são para os x e y da âncora máxima")]
        public Vector4[] posicoesDeAncora;
        [Tooltip("Índice de qual ancora usar")]
        public int indice;
        [Tooltip("Velocidade de interpolação")]
    	public float velocidade;
        [Tooltip("Caso verdadeiro, essa âncora não será alterada")]
        public bool manterSuperiorDireito, manterInferiorEsquerdo;
        [Tooltip("Caso verdadeiro, a velocidade não será influenciada pela escala de tempo")]
        public bool independenteDeTimeScale;

        public void Proxima_Ancoragem() {
            indice++;
            if (indice == posicoesDeAncora.Length)
    			indice = 0;
        }

        public void Ancoragem_Anterior() {
        	indice--;
    		if (indice == 0)
    			indice = posicoesDeAncora.Length-1;
        }

        public void Definir_Indice(int def) {
            indice = def;
        }

        public void Definir_Velocidade(float def) {
            velocidade = def;
        }

        public void Aplicar_Pos_Sem_Interpolacao() {
            Vector2 min = new Vector2(posicoesDeAncora[indice].x, posicoesDeAncora[indice].y);
            Vector2 max = new Vector2(posicoesDeAncora[indice].z, posicoesDeAncora[indice].w);

            if (!manterInferiorEsquerdo)
                rectTransform.anchorMin = min;

            if (!manterSuperiorDireito)
                rectTransform.anchorMax = max;
        }

        void Awake() {
            if (!manterInferiorEsquerdo)
                rectTransform.anchorMin = new Vector2(posicoesDeAncora[indice].x, posicoesDeAncora[indice].y);
            if (!manterSuperiorDireito)
                rectTransform.anchorMax = new Vector2(posicoesDeAncora[indice].z, posicoesDeAncora[indice].w);
        }

        void Update() {
            float dt = independenteDeTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;

            if (!manterInferiorEsquerdo) {
                Vector2 min = new Vector2(posicoesDeAncora[indice].x, posicoesDeAncora[indice].y);
                rectTransform.anchorMin = Vector2.Lerp(rectTransform.anchorMin, min, velocidade * dt);
            }
            if (!manterSuperiorDireito) {
                Vector2 max = new Vector2(posicoesDeAncora[indice].z, posicoesDeAncora[indice].w);
                rectTransform.anchorMax = Vector2.Lerp(rectTransform.anchorMax, max, velocidade * dt);
            }
        }
    }
}
