using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro.Models;
using Cadastro.Services;
using System.Diagnostics;

namespace Cadastro.Controllers
{
    public class CadastrosController : Controller
    {
        private readonly CadastroService _service;

        public CadastrosController(CadastroService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var cadastrados = await _service.FindAllAsync();

            return View(cadastrados);
        }

        public async Task<IActionResult> Create()
        {
            Cadastrado cadastrado = new Cadastrado();

            return View(cadastrado);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Cadastrado cadastrado)
        {
            await _service.AdicionaAsync(cadastrado);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not provided !!!"});
            }

            var user = await _service.FindById(id.Value);
            if (user == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not Found" });
            }

            return View(user);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Cadastrado cadastrado)
        {
            if (id != cadastrado.Id)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id mismatch !!!" });
            }

            try
            {
                await _service.AtualizaAsync(cadastrado);

                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = e.Message });
            }
        }


        public async Task<IActionResult> delete(int? id)
        {

            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not provided !!!" });
            }

            var user = await _service.FindById(id.Value);
            if(user == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not Found!!!" });
            }

            return View(user);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
          
            await _service.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not provided !!!" });
            }

            var user = await _service.FindById(id.Value);
            if (user == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not Found!!!" });
            }

            return View(user);

        }


        public IActionResult Error(string mensagem)
        {
            var viewError = new ErrorViewModel()
            {
                Mensagem = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewError);
        }
    }
}
