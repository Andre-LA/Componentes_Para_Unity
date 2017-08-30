using UnityEngine;
using UnityEngine.UI;

public class Muda_Imagem_UI : MonoBehaviour {
	[Tooltip("Lista de imagens para usar na mudança de imagem")]
	public Sprite[] imgs;
	[Tooltip("Lista de cores das imagens")]
	public Color[] cores;
	[Tooltip("Imagem a ser alterada")]
	public Image img;
	[Tooltip("Índice de qual imagem usar")]
	public int indiceImg;
	[Tooltip("Índice de qual cor usar")]
	public int indiceCor;

	public void Proxima_Imagem () {
		indiceImg++;

		if (indiceImg >= imgs.Length)
			indiceImg = 0;

		img.sprite = imgs [indiceImg];
		img.color = cores [indiceCor];
	}

	public void Imagem_Anterior () {
		indiceImg--;

		if (indiceImg < 0)
			indiceImg = imgs.Length - 1;
		
		img.sprite = imgs [indiceImg];
		img.color = cores [indiceCor];
	}

	public void Definir_Imagem (int i) {
		indiceImg = i;
		img.sprite = imgs [indiceImg];
	}

	public void Proxima_Cor () {
		indiceCor++;

		if (indiceCor >= cores.Length)
			indiceCor = 0;

		img.color = cores [indiceCor];
	}

	public void Cor_Anterior () {
		indiceCor--;

		if (indiceCor < 0)
			indiceCor = cores.Length - 1;
		
		img.color = cores [indiceCor];
	}

	public void Definir_Cor (int i) {
		indiceCor = i;
		img.color = cores [indiceCor];
	}
}
