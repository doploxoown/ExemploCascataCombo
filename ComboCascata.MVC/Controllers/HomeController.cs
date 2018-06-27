using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComboCascata.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private List<PaisViewModel> _listaPais = new List<PaisViewModel>()
            {
                new PaisViewModel() {Id=1, Nome="Brasil"},
                new PaisViewModel() {Id=2, Nome="Estados Unidos"},
                new PaisViewModel() {Id=3, Nome="Canadá"}
            };

        private List<EstadoViewModel> _listaEstado = new List<EstadoViewModel>()
            {
                new EstadoViewModel() {Id=1, Nome="Rio de Janeiro", IdPais=1},
                new EstadoViewModel() {Id=2, Nome="São Paulo", IdPais=1},
                new EstadoViewModel() {Id=3, Nome="Minas Gerais", IdPais=1},
                new EstadoViewModel() {Id=4, Nome="Ceará", IdPais=1},
                new EstadoViewModel() {Id=5, Nome="New York", IdPais=2},
                new EstadoViewModel() {Id=6, Nome="Washington", IdPais=2},
                new EstadoViewModel() {Id=7, Nome="Québec", IdPais=3},
                new EstadoViewModel() {Id=8, Nome="Colúmbia Britanica", IdPais=3},
                new EstadoViewModel() {Id=9, Nome="Ontário", IdPais=3}
            };

        private List<CidadeViewModel> _listaCidade = new List<CidadeViewModel>()
            {
                new CidadeViewModel() {Id=1, Nome="Rio de Janeiro", IdEstado=1},
                new CidadeViewModel() {Id=2, Nome="Mangaratiba", IdEstado=1},
                new CidadeViewModel() {Id=3, Nome="Angra dos Reis", IdEstado=1},
                new CidadeViewModel() {Id=4, Nome="Itaguaí", IdEstado=1},
                new CidadeViewModel() {Id=5, Nome="São Paulo", IdEstado=2},
                new CidadeViewModel() {Id=6, Nome="Taubaté", IdEstado=2},
                new CidadeViewModel() {Id=7, Nome="Minas Gerais", IdEstado=3},
                new CidadeViewModel() {Id=8, Nome="Poços de Caldas", IdEstado=3},
                new CidadeViewModel() {Id=9, Nome="Fortaleza", IdEstado=4},
                new CidadeViewModel() {Id=10, Nome="Pluma", IdEstado=5},
                new CidadeViewModel() {Id=11, Nome="Bronx", IdEstado=7},
                new CidadeViewModel() {Id=12, Nome="ChinaTowm", IdEstado=7},
                new CidadeViewModel() {Id=13, Nome="ChinaTowm56", IdEstado=7},
                new CidadeViewModel() {Id=14, Nome="Teste3", IdEstado=8},
                new CidadeViewModel() {Id=15, Nome="Teste2", IdEstado=8},
                new CidadeViewModel() {Id=16, Nome="Toronto", IdEstado=9}
            };

        public ActionResult Index()
        {
            var ret = new List<PaisViewModel>();
            ret.AddRange(_listaPais);
            ret.Insert(0, new PaisViewModel() { Id = -1, Nome = "Selecione o País" });

            return View(ret);
        }

        [HttpPost]
        public ActionResult ObterEstados(int idPais)
        {
            System.Threading.Thread.Sleep(2000);

            var ret = _listaEstado.FindAll(x => x.IdPais == idPais);
            if (ret.Count > 0)
            {
                ret.Insert(0, new EstadoViewModel() { Id = -1, Nome = "Selecione o Estado" });
            }

            return Json(ret);
        }

        [HttpPost]
        public ActionResult ObterCidades(int idEstado)
        {
            System.Threading.Thread.Sleep(2000);

            var ret = _listaCidade.FindAll(x => x.IdEstado == idEstado);
            if (ret.Count > 0)
            {
                ret.Insert(0, new CidadeViewModel() { Id = -1, Nome = "Selecione a Cidade" });
            }

            return Json(ret);
        }

    }
}