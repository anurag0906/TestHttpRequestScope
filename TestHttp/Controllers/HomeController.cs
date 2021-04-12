using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestHttp.Models;

namespace TestHttp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
       static int reqcount = 0;

        private static List<OperationDetails> opList = new List<OperationDetails>();
        private ISecondInstanceInaCall _secondInstanceInaCall;
        public HomeController(IOperationTransient transientOperation, 
                                IOperationScoped scopedOperation, 
                                IOperationSingleton singletonOperation, 
                                ISecondInstanceInaCall secondInstanceInaCall)
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _secondInstanceInaCall = secondInstanceInaCall;
            
        }

        public IActionResult Index()
        {
            reqcount++;

            opList.Add(new OperationDetails()
            {
                OpId = _transientOperation.SomeGuid, OpName = ScopeType.Transient.ToString()
            });

            opList.Add(new OperationDetails()
            {
                OpId = _scopedOperation.SomeGuid,
                OpName = ScopeType.Scoped.ToString()
            });
            opList.Add(new OperationDetails()
            {
                OpId = _singletonOperation.SomeGuid,
                OpName = ScopeType.Singleton.ToString()
            });

            ViewBag.Round = reqcount;

            ViewBag.Transient = _secondInstanceInaCall._transientOperation.SomeGuid.ToString();
            ViewBag.Scoped = _secondInstanceInaCall._scopedOperation.SomeGuid.ToString();
            ViewBag.Singleton = _secondInstanceInaCall._singletonOperation.SomeGuid.ToString();

            return View("OpDetail", opList);
        }

    }
}
