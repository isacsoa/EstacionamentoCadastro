using AutoMapper;
using EstacionamentoCadastro.Modelo.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoCadastro.Controllers
{
    public class BaseController : Controller
    {
        public IOptions<Parametros> _connectionString { get; set; }
        public IMapper _mapper;
        public IToastNotification _toastNotification;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public BaseController(IOptions<Parametros> connectionString, IMapper mapper, IToastNotification toastNotification)
        {
            _connectionString = connectionString;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }
    }
}
