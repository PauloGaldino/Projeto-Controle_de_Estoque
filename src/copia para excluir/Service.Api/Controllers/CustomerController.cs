using Application.EventSourcingNormalize.Perspns;
using Application.Interfaces.Persons;
using Application.ViewModels.Persons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Api.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [AllowAnonymous]
        [HttpGet("customer-management")]
        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            return await _customerAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("customer-management/{id:guid}")]
        public async Task<CustomerViewModel> Get(Guid id)
        {
            return await _customerAppService.GetById(id);
        }

        [CustomAuthorize("Customers", "Write")]
        [HttpPost("customer-management")]
        public async Task<IActionResult> Post([FromBody] CustomerViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _customerAppService.Register(customerViewModel));
        }

        [CustomAuthorize("Custumers", "Write")]
        [HttpGet("sustumer-management")]
        public async Task<IActionResult> Put([FromBody] CustomerViewModel customerViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _customerAppService.Update(customerViewModel));
        }

        [CustomAuthorize("Customers", "Remove")]
        [HttpDelete("customer-management")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _customerAppService.Remove(id));
        }


        [AllowAnonymous]
        [HttpGet("customer-management/history/{id:guid}")]
        public async Task<IList<CustomerHistoryData>> History(Guid id)
        {
            return await _customerAppService.GetAllHistory(id);
        }
    }
}
