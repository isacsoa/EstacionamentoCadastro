using AutoMapper;
using EstacionamentoCadastro.Business;
using EstacionamentoCadastro.Modelo;
using EstacionamentoCadastro.Modelo.Core;
using EstacionamentoCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NToastNotify;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoCadastro.Controllers
{
    public class CarroController : BaseController
    {
        private readonly Parametros parametros;
        private readonly ILogger<CarroController> logger;
        private readonly CarroBLL carroBLL;


        public CarroController(IOptions<Parametros> connectionString,
            Parametros parametros,
            IMapper mapper,
            IToastNotification toastNotification,
            ILogger<CarroController> logger, 
            CarroBLL carroBLL
            ) : base(connectionString, mapper, toastNotification)
        {
            this.parametros = parametros;
            this.logger = logger;
            this.carroBLL = carroBLL;
        }

        public IActionResult Index()
        {
            try
            {
                PreencheViewBag();

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Listar()
        {
            try
            {
                int itemsPorPagina = 100;
                //if (filtro.OrdenacaoDirecao == Enumerador.SortDirection.Descending)
                //    filtro.Ordenacao += 1;
                //filtro.Pagina = filtro.Pagina ?? 1;
                //filtro.QuantidadePorPagina = itemsPorPagina;
                //filtro.IdCliente = parametros.IdCliente;

                //ViewBag.OrdenacaoDirecao = filtro.OrdenacaoDirecao ?? Enumerador.SortDirection.Ascending;
                ViewBag.OrdenacaoDirecao = 1;
                ViewBag.Ordenacao = 1;
                ViewBag.Pagina = 1;

                var carros = carroBLL.Listar();
                var list = _mapper.Map<List<CarroViewModel>>(carros);

                var firstOrDefault = list.FirstOrDefault();

                int qtd = list.Count;
                

                var pagedList = new StaticPagedList<CarroViewModel>(list, 1, itemsPorPagina, qtd);

                return PartialView("_List", pagedList);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return PartialView("_List");
            }
        }

        #region create
        [HttpGet]
        //[CustomRoleProvider.AccessDeniedAuthorize(Roles = "UsuarioIncluir")]
        public ActionResult Create()
        {
            try
            {
                CarroViewModel dados = new CarroViewModel();

                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Carro");
            }
        }

        [HttpPost]
        //[CustomRoleProvider.AccessDeniedAuthorize(Roles = "UsuarioIncluir")]
        public ActionResult Create(CarroViewModel dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Carro carro = _mapper.Map<CarroViewModel, Carro>(dados);

                    carroBLL.Incluir(carro);

                    _toastNotification.AddSuccessToastMessage();
                    return Redirect("Index");
                }

                _toastNotification.AddWarningToastMessage("Verifique se todos os campos estão preenchidos corretamente.");
                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Carro");
            }
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Carro carro = carroBLL.ObterPorId(id);

                CarroViewModel dados = _mapper.Map<Carro, CarroViewModel>(carro);

                PreencheViewBag();

                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Carro");
            }
        }

        [HttpPost]
        public ActionResult Edit(CarroViewModel dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Carro carro = _mapper.Map<CarroViewModel, Carro>(dados);

                    carroBLL.Atualizar(carro);

                    _toastNotification.AddSuccessToastMessage();
                    return RedirectToAction("Index", "Carro");
                }

                PreencheViewBag();
                _toastNotification.AddWarningToastMessage("Verifique se todos os campos estão preenchidos corretamente.");
                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Carro");
            }
        }
        #endregion

        #region excluir
        [HttpGet]
        public ActionResult Excluir(long id)
        {
            try
            {
                carroBLL.Excluir(id);

                _toastNotification.AddSuccessToastMessage();
                return RedirectToAction("Index", "Carro");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Carro");
            }
        }
        #endregion

        //public ActionResult FillCargoPorDepartamento(int idDepartamento)
        //{
        //    var cargos = new CargoBLL(_connectionString).ListarPorFiltro(new CargoFiltro() { IdDepartamento = idDepartamento });
        //    return Json(cargos);
        //}

        public void PreencheViewBag()
        {
            //List<SelectListItem> lstDepartamentos = new DepartamentoBLL(_connectionString).ListarPorFiltro(new DepartamentoFiltro() { IdCliente = parametros.IdCliente, Ordenacao = 1 }).Select(x => new SelectListItem() { Text = x.Nome, Value = x.IdDepartamento.ToString() }).ToList();
            //ViewBag.Departamentos = lstDepartamentos;
        }
    }
}
