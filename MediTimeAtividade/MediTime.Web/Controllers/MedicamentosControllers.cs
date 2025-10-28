using AutoMapper; // <-- ADICIONADO
using MediTime.Application.Interfaces;
using MediTime.Application.ViewModels;
using MediTime.Domain.Interfaces; // <-- ADICIONADO
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // <-- ADICIONADO

namespace MediTime.Web.Controllers
{
    public class MedicamentosController : Controller
    {
        private readonly IMedicamentoService _medicamentoService;
        private readonly IMapper _mapper; // <-- ADICIONADO
        private readonly IMedicamentoRepository _medicamentoRepository; // <-- ADICIONADO

        // Construtor modificado para receber os novos serviços
        public MedicamentosController(IMedicamentoService medicamentoService, IMapper mapper, IMedicamentoRepository medicamentoRepository)
        {
            _medicamentoService = medicamentoService;
            _mapper = mapper; // <-- ADICIONADO
            _medicamentoRepository = medicamentoRepository; // <-- ADICIONADO
        }

        // GET: /Medicamentos
        public async Task<IActionResult> Index()
        {
            var model = await _medicamentoService.GetAllAsync();
            return View(model);
        }

        // GET: /Medicamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Medicamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicamentoCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _medicamentoService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        
        // --- INÍCIO DAS NOVAS AÇÕES (EDIT) ---

        // GET: /Medicamentos/Edit/5
        // Mostra o formulário preenchido para edição
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // 1. Busca o medicamento no banco
            var medicamento = await _medicamentoRepository.GetByIdAsync(id.Value); 

            if (medicamento == null)
            {
                return NotFound();
            }

            // 2. Mapeia a Entidade para o EditViewModel
            var model = _mapper.Map<MedicamentoEditViewModel>(medicamento);

            // 3. Envia o modelo para a View
            return View(model);
        }

        // POST: /Medicamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MedicamentoEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 4. Manda o serviço atualizar
                    await _medicamentoService.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException) 
                {
                    // Lidar se o item foi excluído por outro usuário
                    return NotFound();
                }
                
                // 5. Redireciona para a lista
                return RedirectToAction(nameof(Index));
            }
            
            // Se o modelo for inválido, retorna para a tela de edição
            return View(model);
        }
        // --- FIM DAS NOVAS AÇÕES (EDIT) ---


        // GET: /Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medicamento = await _medicamentoService.GetByIdAsync(id.Value);
            if (medicamento == null)
            {
                return NotFound();
            }
            return View(medicamento);
        }

        // POST: /Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _medicamentoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}