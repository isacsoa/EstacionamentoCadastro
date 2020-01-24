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
    public class CarroManobradoController : BaseController
    {
        private readonly Parametros parametros;
        private readonly ILogger<CarroManobradoController> logger;
        private readonly CarroManobradoBLL carroManobradoBLL;
        private readonly CarroBLL carroBLL;
        private readonly ManobristaBLL manobristaBLL;
               
        public CarroManobradoController(IOptions<Parametros> connectionString,
            Parametros parametros,
            IMapper mapper,
            IToastNotification toastNotification,
            ILogger<CarroManobradoController> logger,
            CarroManobradoBLL carroManobradoBLL,
            CarroBLL carroBLL,
            ManobristaBLL manobristaBLL
            ) : base(connectionString, mapper, toastNotification)
        {
            this.parametros = parametros;
            this.logger = logger;
            this.carroManobradoBLL = carroManobradoBLL;
            this.carroBLL = carroBLL;
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

                ViewBag.OrdenacaoDirecao = 1;
                ViewBag.Ordenacao = 1;
                ViewBag.Pagina = 1;

                var carrosManobrados = carroManobradoBLL.Listar();
                var list = _mapper.Map<List<CarroManobradoViewModel>>(carrosManobrados);

                var firstOrDefault = list.FirstOrDefault();

                int qtd = list.Count;
                

                var pagedList = new StaticPagedList<CarroManobradoViewModel>(list, 1, itemsPorPagina, qtd);

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
                CarroManobradoViewModel dados = new CarroManobradoViewModel();
                PreencheViewBag();

                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "CarroManobrado");
            }
        }

        [HttpPost]
        //[CustomRoleProvider.AccessDeniedAuthorize(Roles = "UsuarioIncluir")]
        public ActionResult Create(CarroManobradoViewModel dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CarroManobrado carroManobrado = _mapper.Map<CarroManobradoViewModel, CarroManobrado>(dados);

                    carroManobradoBLL.Incluir(carroManobrado);

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
                return RedirectToAction("Index", "CarroManobrado");
            }
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                CarroManobrado carroManobrado = carroManobradoBLL.ObterPorId(id);

                CarroManobradoViewModel dados = _mapper.Map<CarroManobrado, CarroManobradoViewModel>(carroManobrado);

                PreencheViewBag();

                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "CarroManobrado");
            }
        }

        [HttpPost]
        public ActionResult Edit(CarroManobradoViewModel dados)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CarroManobrado carroManobrado = _mapper.Map<CarroManobradoViewModel, CarroManobrado>(dados);

                    carroManobradoBLL.Atualizar(carroManobrado);

                    _toastNotification.AddSuccessToastMessage();
                    return RedirectToAction("Index", "CarroManobrado");
                }

                PreencheViewBag();
                _toastNotification.AddWarningToastMessage("Verifique se todos os campos estão preenchidos corretamente.");
                return View(dados);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "CarroManobrado");
            }
        }
        #endregion

        #region excluir
        [HttpGet]
        public ActionResult Excluir(long id)
        {
            try
            {
                carroManobradoBLL.Excluir(id);

                _toastNotification.AddSuccessToastMessage();
                return RedirectToAction("Index", "CarroManobrado");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                _toastNotification.AddErrorToastMessage();
                return RedirectToAction("Index", "CarroManobrado");
            }
        }
        #endregion

        public void PreencheViewBag()
        {
            var lstCarros = carroBLL.Listar().Select(x => new SelectListItem() { Text = $"{x.Marca} / {x.Modelo} / {x.Placa} " , Value = x.Id.ToString() }).ToList();
            ViewData["Carros"] = lstCarros;

            var lstManobristas = manobristaBLL.Listar().Select(x => new SelectListItem() { Text = x.NomeManobrista, Value = x.Id.ToString() }).ToList();
            ViewData["Manobristas"] = lstManobristas;
        }
    }
}
