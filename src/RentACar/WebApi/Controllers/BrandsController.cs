using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Common;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse result = await Mediator.Send(createBrandCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedBrandCommand updatedBrandCommand)
        {
            UpdateBrandResponse result = await Mediator.Send(updatedBrandCommand);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            DeleteBrandCommand updatedBrandCommand = new() { Id = id };
            DeletedBrandResponse result = await Mediator.Send(updatedBrandCommand);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new GetListBrandQuery() { PageRequest = pageRequest };
            GetListResponse<GetListBrandListItemDto> result = await Mediator.Send(getListBrandQuery);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getByIdBrandQuery = new() { Id = id };
            GetByIdBrandResponse result = await Mediator.Send(getByIdBrandQuery);

            return Ok(result);
        }
    }
}
