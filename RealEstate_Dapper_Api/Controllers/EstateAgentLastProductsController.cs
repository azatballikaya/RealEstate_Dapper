﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly ILast5ProductRepository _lastProductRepository;

        public EstateAgentLastProductsController(ILast5ProductRepository lastProductRepository)
        {
            this._lastProductRepository = lastProductRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLast5Products(int id)
        {
            var values=await _lastProductRepository.GetLast5ProductsAsync(id);
            return Ok(values);
        }
    }
}
