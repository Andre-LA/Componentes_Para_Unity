using UnityEngine;
using UnityEngine.UI;

public class Interpolacao_De_Cor : MonoBehaviour {
	[Tooltip("Componente que terá sua propriedade de cor alterada")]
	public Component alvo;
	
		
	[Tooltip("Qual o tipo do componente acima")]
	public TiposGUI tipo;

	public Color[] cores;
	public int indice;
	public float velocidade;
	public bool independenteDeTimeScale;

	public void Definir_Velocidade (float def) {
		velocidade = def;
	}

	public void Proxima_Cor() {
        indice++;
        if (indice == cores.Length)
			indice = 0;
    }

    public void Cor_Anterior() {
    	indice--;
		if (indice == 0)
			indice = cores.Length-1;
    }

    public void Definir_Indice(int def) {
        indice = def;
    }

	void Update() {
		switch (tipo) {
			case TiposGUI.Imagem:
				Image alvo_img = alvo as Image;
				alvo_img.color = Color.Lerp(alvo_img.color, cores[indice], velocidade * (independenteDeTimeScale ? Time.unscaledDeltaTime : Time.deltaTime));
			break;
			case TiposGUI.Texto:
				Text alvo_txt = alvo as Text;
				alvo_txt.color = Color.Lerp(alvo_txt.color, cores[indice], velocidade * (independenteDeTimeScale ? Time.unscaledDeltaTime : Time.deltaTime));
			break;
			default:
				Debug.LogError("Tipo de componente não suportado");
			break;
		}
	}
}
