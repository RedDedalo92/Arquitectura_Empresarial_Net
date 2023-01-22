using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;
        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        #region Metodos sincronos
        //[HttpPost]
        //public IActionResult Insert([FromBody]CustomerDTO customerDTO)
        //{
        //    if (customerDTO == null) return BadRequest();

        //    var response = _customerApplication.Insert(customerDTO);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest(response.Message);
        //}

        //[HttpPut]
        //public IActionResult Update([FromBody] CustomerDTO customerDTO)
        //{
        //    if (customerDTO == null) return BadRequest();

        //    var response = _customerApplication.Update(customerDTO);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest(response.Message);

        //}

        //[HttpDelete("customerId")]
        //public IActionResult Delete(string customerId)
        //{
        //    if (string.IsNullOrEmpty(customerId)) return BadRequest();

        //    var response = _customerApplication.Delete(customerId);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest(response.Message);
        //}

        //[HttpGet("customerId")]
        //public IActionResult Get(string customerId)
        //{
        //    if (string.IsNullOrEmpty(customerId)) return BadRequest();

        //    var response = _customerApplication.Get(customerId);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest(response.Message);
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var response = _customerApplication.GetAll();
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest(response.Message);
        //}
        #endregion

        #region Metodos asincronos
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = await _customerApplication.InsertAsync(customerDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null) return BadRequest();

            var response = await _customerApplication.UpdateAsync(customerDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);

        }

        [HttpDelete("customerId")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customerApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("customerId")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();

            var response = await _customerApplication.GetAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }
        #endregion
    }
}
