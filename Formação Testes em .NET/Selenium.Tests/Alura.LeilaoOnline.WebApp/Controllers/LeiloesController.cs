using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Extensions;
using Alura.LeilaoOnline.WebApp.Filtros;
using Alura.LeilaoOnline.WebApp.Dados;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [AutorizacaoFilterAttribute]
    public class LeiloesController : Controller
    {
        private readonly IRepositorio<Leilao> _repo;
        private readonly IWebHostEnvironment _env;

        private string TentaGravarImagemDestaqueERetornaSeuNome(IFormFile upload)
        {
            if (upload != null)
            {
                var nomeArquivoServidor = Path.Combine(
                    _env.WebRootPath,
                    "images",
                    upload.FileName);
                using (var stream = new FileStream(nomeArquivoServidor, FileMode.OpenOrCreate))
                {
                    upload.CopyTo(stream);
                }
            }
            return $"/images/{upload.FileName}";
        }

        public LeiloesController(IRepositorio<Leilao> repositorio, IWebHostEnvironment environment)
        {
            _repo = repositorio;
            _env = environment;
        }

        public IActionResult Index()
        {
            var leiloes = _repo.Todos.Select(l => l.ToViewModel());
            return View(leiloes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(LeilaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                //gravar arquivo com a imagem definida
                model.Imagem = this.TentaGravarImagemDestaqueERetornaSeuNome(model.ArquivoImagem);
                var novoLeilao = model.ToModel();
                _repo.Incluir(novoLeilao);
                return RedirectToAction("Index");
            }
            return View("Novo", model);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            //var leilao = _repo.BuscarPorId(id);
            var leilao = new LeilaoViewModel();
            if(leilao != null)
            {
                //_repo.Excluir(leilao);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}