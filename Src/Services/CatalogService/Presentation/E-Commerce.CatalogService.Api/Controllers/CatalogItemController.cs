using E_Commerce.CatalogService.Application.Abstractions.Services;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Command.CreatCatalogItem;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Command.DeleteCatalogItem;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Command.UpdateCatalogItem;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Queries.GetCatalogItem;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Queries.GetCatalogItemsByBrand;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Queries.GetCatalogItemsByCategory;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Queries.GetListCatalogItem;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemController : BaseController
    {
        private readonly ICatalogBrandService _brandService;
        private readonly ICatalogTypeService _typeService;

        public CatalogItemController(ICatalogBrandService brandService, ICatalogTypeService typeService)
        {
            _brandService = brandService;
            _typeService = typeService;
        }

        [HttpPost("AddCatalogItem")]
        public async Task<IActionResult> Create([FromForm] CreatCatalogItemCommand createCatalogItemCommand)
        {
            return Ok(await _mediator.Send(createCatalogItemCommand));
        }

        [HttpPut("UpdateCatalogItem")]
        public async Task<IActionResult> Update([FromForm] UpdateCatalogItemCommand updateCatalogItemCommand)
        {
            return Ok(await _mediator.Send(updateCatalogItemCommand));
        }

        [HttpGet("GetCatalogList")]
        public async Task<IActionResult> Get([FromQuery] GetListCatalogItemQuery getListCatalogItemCommand)
        {
            return Ok(await _mediator.Send(getListCatalogItemCommand));
        }

        [HttpGet("GetCatalogItem/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCatalogItemQuery getCatalogItemQuery)
        {
            return Ok(await _mediator.Send(getCatalogItemQuery));
        }


        [HttpGet("GetCatalogItemsByType")]
        public async Task<IActionResult> GetCatalogItemsByType([FromQuery] GetCatalogItemsByTypeQuery query)
        {
            return Ok(await _mediator.Send(query));
        }



        [HttpGet("GetCatalogBrandsAndTypes")]
        public async Task<IActionResult> GetCatalogBrandsAndTypes()
        {
            return Ok(new
            {
                Brands = await _brandService.GetBrands(),
                Types = await _typeService.GetCatalogTypes()
            });
        }

        [HttpGet("GetCatalogTypes")]
        public async Task<IActionResult> GetCatalogTypes()
        {
            return Ok(await _typeService.GetCatalogTypes());
        }

        [HttpGet("GetCatalogItemsByBrand")]
        public async Task<IActionResult> GetCatalogItemsByBrand([FromQuery] GetCatalogItemsByBrandQuery query)
        {
            return Ok(await _mediator.Send(query));
        }


        [HttpDelete("DeleteCatalogItem/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCatalogItemCommand deleteCatalogItemCommand)
        {
            return Ok(await _mediator.Send(deleteCatalogItemCommand));
        }
    }
}
