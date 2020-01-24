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
    public class ManobristaController : BaseController
    {
        private readonly Parametros parametros;
        private readonly ILogger<ManobristaController> logger;
        private readonly ManobristaBLL manobristaBLL;


        public ManobristaController(IOptions<Parametros> connectionString,
            Parametros parametros,
            IMapper mapper,
            IToastNotification toastNotification,
            ILogger<ManobristaController> logger, 
            ManobristaBLL manobristaBLL
            ) : base(connectionString, mapper, toastNotification)
        {
            this.parametros = parametros;
            this.logger = logger;
            this.manobristaBLL = manobristaBLL;
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

                var manobristas = manobristaBLL.Listar();
                var list = _mapper.Map<List<ManobristaViewModel>>(manobristas);

                var firstOrDefault = list.FirstOrDefault();

                int qtd = list.Count;
                

                var pagedList = new StaticPagedList<ManobristaViewModel>(list, 1, itemsPorPagina, qtd);

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
                ManobristaViewModel dados = new ManobristaViewModel();

                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Manobrista");
            }
        }

        [HttpPost]
        //[CustomRoleProvider.AccessDeniedAuthorize(Roles = "UsuarioIncluir")]
        public ActionResult Create(ManobristaViewModel dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manobrista manobrista = _mapper.Map<ManobristaViewModel, Manobrista>(dados);

                    manobristaBLL.Incluir(manobrista);

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
                return RedirectToAction("Index", "Manobrista");
            }
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Manobrista manobrista = manobristaBLL.ObterPorId(id);

                ManobristaViewModel dados = _mapper.Map<Manobrista, ManobristaViewModel>(manobrista);

                PreencheViewBag();

                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Manobrista");
            }
        }

        [HttpPost]
        public ActionResult Edit(ManobristaViewModel dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Manobrista manobrista = _mapper.Map<ManobristaViewModel, Manobrista>(dados);

                    manobristaBLL.Atualizar(manobrista);

                    _toastNotification.AddSuccessToastMessage();
                    return RedirectToAction("Index", "Manobrista");
                }

                PreencheViewBag();
                _toastNotification.AddWarningToastMessage("Verifique se todos os campos estão preenchidos corretamente.");
                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Manobrista");
            }
        }
        #endregion

        #region excluir
        [HttpGet]
        public ActionResult Excluir(long id)
        {
            try
            {
                manobristaBLL.Excluir(id);

                _toastNotification.AddSuccessToastMessage();
                return RedirectToAction("Index", "Manobrista");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "Manobrista");
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
