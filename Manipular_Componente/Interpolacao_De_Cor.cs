using UnityEngine;
using UnityEngine.UI;
using Componentes_Para_Unity.Enumeracoes;

namespace Componentes_Para_Unity.Manipular_Componente {
    public class Interpolacao_De_Cor : MonoBehaviour {
    	[Tooltip("Componente que terá sua propriedade de cor alterada")]
    	public Component alvo;

    	[Tooltip("Qual o tipo do componente acima")]
    	public Componentes_Com_Cor tipo;

    	public Color[] cores;
    	public int indice;
    	public float velocidade;
        public AnimationCurve curvaDeInterpolacao;
    	public bool independenteDeTimeScale;

        float interpolacao;

        void Start() {
            Aplicar_Sem_Interpolar();
        }

        void Update() {
            Aplicar();
        }

    	public void Definir_Velocidade (float def) {
    		velocidade = def;
    	}

    	public void Proxima_Cor() {
            indice++;
            if (indice == cores.Length)
    			indice = 0;
            interpolacao = 0;
        }

        public void Cor_Anterior() {
        	indice--;
    		if (indice == 0)
    			indice = cores.Length-1;
            interpolacao = 0;
        }

        public void Definir_Indice(int def) {
            indice = def;
            interpolacao = 0;
        }

        public void Definir_Interpolacao(float def) {
            if (def < 0 || def > 1 )
                Debug.LogError("Definição de interpolação deve ser entre 0 e 1");
            else
                interpolacao = def;
        }

        void Aplicar_Sem_Interpolar() {
            switch (tipo) {
    			case Componentes_Com_Cor.Imagem:
    				Image alvo_img = alvo as Image;
    				alvo_img.color = cores[indice];
    			break;
    			case Componentes_Com_Cor.Texto:
    				Text alvo_txt = alvo as Text;
    				alvo_txt.color = cores[indice];
    			break;
                case Componentes_Com_Cor.Sprite_Renderer:
    				SpriteRenderer alvo_sr = alvo as SpriteRenderer;
    				alvo_sr.color = cores[indice];
    			break;
    			default:
    				Debug.LogError("Tipo de componente não suportado");
    			break;
    		}
        }

        void Aplicar() {
            if (interpolacao == 1)
                return;

            if (interpolacao < 1)
                interpolacao += velocidade * (independenteDeTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
            if (interpolacao > 1)
                interpolacao = 1;

    		switch (tipo) {
    			case Componentes_Com_Cor.Imagem:
    				Image alvo_img = alvo as Image;
    				alvo_img.color = Color.Lerp(alvo_img.color, cores[indice], curvaDeInterpolacao.Evaluate(interpolacao));
    			break;
    			case Componentes_Com_Cor.Texto:
    				Text alvo_txt = alvo as Text;
    				alvo_txt.color = Color.Lerp(alvo_txt.color, cores[indice], curvaDeInterpolacao.Evaluate(interpolacao));
    			break;
                case Componentes_Com_Cor.Sprite_Renderer:
    				SpriteRenderer alvo_sr = alvo as SpriteRenderer;
    				alvo_sr.color = Color.Lerp(alvo_sr.color, cores[indice], curvaDeInterpolacao.Evaluate(interpolacao));
    			break;
    			default:
    				Debug.LogError("Tipo de componente não suportado");
    			break;
    		}
        }
    }
}
