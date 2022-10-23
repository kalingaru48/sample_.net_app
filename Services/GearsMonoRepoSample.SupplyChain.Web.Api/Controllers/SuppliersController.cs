using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using GearsMonoRepoSample.SupplyChain.Web.Api.Services.Foundations.Suppliers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GearsMonoRepoSample.SupplyChain.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : RESTFulController
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                IQueryable<Supplier> suppliers = 
                    this.supplierService.RetrieveAllSuppliers();

                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpGet("{supplierId}")]
        public ActionResult<Supplier> GetSupplierById(Guid supplierId)
        {
            try
            {
                var supplier = 
                    this.supplierService.RetrieveSupplierById(supplierId);
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Supplier> PostSupplier(Supplier supplier)
        {
            try
            {
                var postedSupplier =
                    this.supplierService.AddSupplier(supplier);

                return Created(supplier);
            } 
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<Supplier> PutSupplier(Supplier supplier)
        {
            try
            {
                var modifiedSupplier =
                    this.supplierService.ModifySupplier(supplier);

                return Ok(modifiedSupplier);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<Supplier> DeleteSupplierById(Guid supplierId)
        {
            try
            {
                var deletedSupplier = 
                    this.supplierService.RemoveSupplier(supplierId);

                return Ok(deletedSupplier);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
