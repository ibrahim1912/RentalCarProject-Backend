using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : ControllerBase
    {
        private IFakePaymentService _fakePaymentService;

        public FakePaymentController(IFakePaymentService fakePaymentService)
        {
            _fakePaymentService = fakePaymentService;
        }

        [HttpPost("fakepayment")]

        public IActionResult FakePaymentExist(FakePayment fakePayment)
        {
            var result = _fakePaymentService.FakePaymentExist(fakePayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

