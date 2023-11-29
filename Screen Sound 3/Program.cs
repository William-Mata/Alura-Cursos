using Screen_Sound_3.Menus;

// SCREEN SOUND
#region Variáveis 
Dictionary<int, Menu> opcoes = new();
opcoes.Add(0, new MenuSair());
opcoes.Add(1, new RegistrarBanda());
opcoes.Add(2, new MenuExibirTodasBandas());
opcoes.Add(3, new MenuAvaliarBanda());
opcoes.Add(4, new MenuExibirMediaAvaliacaoBanda());
opcoes.Add(5, new RegistrarAlbum());
opcoes.Add(6, new MenuExibirDetalhes());
MenuOpcoes menuOpcoes = new MenuOpcoes(opcoes);
#endregion

#region Métodos
menuOpcoes.ExibirOpcoesDoMenu();
#endregion