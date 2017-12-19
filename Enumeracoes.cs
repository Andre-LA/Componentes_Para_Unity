public enum Condicoes {
    menorQue,
    maiorQue,
    igualA,
    diferente,
    maiorOuIgualAQue,
    menorOuIgualAQue,
}

public enum Operadores {
    adicao,
    substracao,
    multiplicacao,
    divisao,
    modulo,
    incremento,
    decremento,
}

public enum Medidas_De_Tempo {
    nanoSegundo, microSegundo, miliSegundo,
    segundo, minuto, hora,
    dia, semana, mes,
    bimestre, trimestre,
    ano, decada, seculo, milenio,
}

public enum SI_prefixos {
    nano = -9,
    micro = -6,
    mili = -3,
    kilo = 3,
    mega = 6,
    giga = 9,
}

public enum Tipos {
	inteiro,
	String,
	flutuante,
	duploFlutuante,
    booleano,
}

public enum Componentes_Com_Cor {
	Imagem,
    Texto,
    Botao,
    Sprite_Renderer,
}

public enum Formas_De_Obter_Eixos {
    Obter_Eixos,
    Obter_Eixos_Puros,
    Obter_Botao,
    Obter_Botao_Baixo,
    Obter_Botao_Cima,
    Nao_Obter,
}

public enum OrdemNumerica {
    SequencialIncremento,
    SequencialDecremento,
    Aleatoria,
}

public enum Plataforma {
    PC,
    Console,
    Mobile,
    VR,
}

public enum Configuracao {
    Qualidade,
    Resolucao,
    TelaCheia,
    VSync,
    VolumeGeral,
    VolumeMusica,
    VolumeEfeitosSonoros,
}
