using InvoiceProj.Repositories;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InvoiceProj.Models;
using InvoiceProj.Dtos;
using InvoiceProj.Helpers;
using System.Collections.Generic;
using System.Linq;
namespace InvoiceProj.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository<Invoice> _invoiceRepository;

        public InvoiceController(IInvoiceRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<ActionResult> Index()
        {
            var invoices = _invoiceRepository.list();
            var invoiceResult = new List<InvoiceDto>();
            //TODO: use AutoMapper
            foreach (var invoice in invoices)
            {
                invoiceResult.Add(new InvoiceDto()
                {
                    Id = invoice.Id,
                    CreationDate = DateOnly.FromDateTime(invoice.CreationDate),
                    CustomerName = invoice.CustomerName,
                    Description = invoice.Description,
                    PaymentMethod = invoice.PaymentMethod,
                    TotalPayment = invoice.Items.Sum(x => x.Price * x.Quantity)
                });
            }
            return View(invoiceResult);
        }
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var invoice = _invoiceRepository.find(id);
            if(invoice == null)
            {
                return NotFound();
            }
            var invoiceResult = new InvoiceDetailedDto()
            {
                Id = invoice.Id,
                CreationDate = invoice.CreationDate.ToString("dd/MM/yyyy"),
                CustomerName = invoice.CustomerName,
                Description = invoice.Description,
                PaymentMethod = invoice.PaymentMethod,
                Items = invoice.Items.ToList()
            };
            return View(invoiceResult);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateInvoiceDto invoiceDto)
        {
            if(string.IsNullOrEmpty(invoiceDto.CustomerName) ||
                invoiceDto.Items.Count == 0){
                //TODO: return validation message
                return View(invoiceDto);
            }
            var invoice = new Invoice()
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                CustomerName = invoiceDto.CustomerName,
                Description = invoiceDto.Description,
                PaymentMethod = invoiceDto.PaymentMethod,
            };
            invoice.Items = new List<InvoiceItem>();

            foreach (var item in invoiceDto.Items)
            {
                if (ValidItem(item))
                {
                    invoice.Items.Add(new InvoiceItem()
                    {
                        ItemCode = item.ItemCode,
                        Id = Guid.NewGuid(),
                        ItemName = item.ItemName,
                        Price = item.Price,
                        Quantity = item.Quantity
                    });
                }

            }
            double price = invoice.Items.Sum(x => x.Price * x.Quantity);

            if (price > ApplicationConsts.MaxPaymentForCredit && invoice.PaymentMethod == PaymentMethodEnum.Credit)
            {
                //TODO: Add validation message
                return View(invoiceDto);
            }
            _invoiceRepository.add(invoice);
            return RedirectToAction(nameof(Index));
        }
        private bool ValidItem(InvoiceItem item)
        {
            return !string.IsNullOrEmpty(item.ItemName) && item.Price > 0 && item.Quantity > 0 && item.ItemCode > 0;
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            //TODO: Edit the invoice must be done by an admin user
            var invoice = _invoiceRepository.find(id);
            var invoiceResult = new CreateInvoiceDto()
            {
                Id = invoice.Id,
                CustomerName = invoice.CustomerName,
                Description = invoice.Description,
                PaymentMethod = invoice.PaymentMethod,
                Items = invoice.Items.ToList()
            };
            return View(invoiceResult);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, CreateInvoiceDto invoiceDto)
        {
            if (ModelState.IsValid)
            {
                var invoice = new Invoice()
                {
                    Id = id,
                    CreationDate = DateTime.Now,
                    CustomerName = invoiceDto.CustomerName,
                    Description = invoiceDto.Description,
                    PaymentMethod = invoiceDto.PaymentMethod,
                    Items = invoiceDto.Items
                };
                _invoiceRepository.update(id, invoice);
                return RedirectToAction(nameof(Index));
            }
            //TODO:(Validation Message)return model state errors
            return View(invoiceDto);
        }
        public async Task<ActionResult> Delete(Guid id)
        {
            //TODO: Add Validation if invoice is null
            _invoiceRepository.delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}