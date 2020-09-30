using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra;
using Service.Models;
using Infra.Repositoy;
using Domain.Interfaces;

namespace Service.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClient _clientRepository;
        public ClientsController(IClient clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        //Listagem de clientes
        public async Task<IActionResult> Index()
        {
            var clients = await _clientRepository.GetAllAsync();

            var clientViewModel = clients.Select(x => new ClientViewModel
            {
                Cpf = x.Cpf,
                Email = x.Email,
                Name = x.Name,
                Id = x.Id
            }).ToList();

            return View(clientViewModel);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientViewModel = new ClientViewModel
            {
                Name = client.Name,
                Cpf = client.Cpf,
                Email = client.Email
            };

            return View(clientViewModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Cpf")] ClientViewModel clientViewModel)
        {
            if (ModelState.IsValid)
            {
                var client = new Client(clientViewModel.Name, clientViewModel.Email, clientViewModel.Cpf);

                _clientRepository.Add(client);
                await _clientRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(clientViewModel);
        }

        // UpDate
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var clientViewModel = new ClientViewModel
            {
                Name = client.Name,
                Cpf = client.Cpf,
                Email = client.Email,
                Id = client.Id
            };
            return View(clientViewModel);
        }

        //UpDate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Email,Cpf,Id")] ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var client = new Client(clientViewModel.Name, clientViewModel.Email, clientViewModel.Cpf);
                    client.Id = clientViewModel.Id;
                    _clientRepository.UpDate(client);
                    await _clientRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ClientExists(clientViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clientViewModel);
        }

        // Remove
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            var clientViewModel = new ClientViewModel
            {
                Name = client.Name,
                Cpf = client.Cpf,
                Email = client.Email,
                Id = client.Id
            };
            return View(clientViewModel);
        }

        // Remove
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _clientRepository.Remove(id);
            await _clientRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> ClientExists(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client != null)
            {
                return true;
            }
            return false;
        }
    }
}
