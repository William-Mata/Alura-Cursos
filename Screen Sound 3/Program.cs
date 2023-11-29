using OpenAI_API.Chat;
using OpenAI_API;
using Screen_Sound_3.Menus;
using Screen_Sound_3.Client;

ChatGPT chatGPT = new();

Dictionary<int, Menu> opcoes = new();
opcoes.Add(0, new MenuSair());
opcoes.Add(1, new MenuRegistrarBanda());
opcoes.Add(2, new MenuRegistrarAlbum());
opcoes.Add(3, new MenuAvaliarBanda());
opcoes.Add(4, new MenuAvaliarAlbum());
opcoes.Add(5, new MenuExibirTodasBandas());
opcoes.Add(6, new MenuExibirMediaAvaliacaoBanda());
opcoes.Add(7, new MenuExibirDetalhes());
MenuOpcoes menuOpcoes = new MenuOpcoes(opcoes);

menuOpcoes.ExibirOpcoesDoMenu();