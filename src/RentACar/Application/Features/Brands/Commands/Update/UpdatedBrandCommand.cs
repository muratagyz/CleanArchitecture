using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdatedBrandCommand : IRequest<UpdateBrandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdatedBrandCommandHandler : IRequestHandler<UpdatedBrandCommand, UpdateBrandResponse>
    {
        private readonly IBrandRepository _repository;
        private readonly IMapper _mapper;

        public UpdatedBrandCommandHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateBrandResponse> Handle(UpdatedBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = await _repository.GetAsync(predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken);

            brand = _mapper.Map(request, brand);

            await _repository.UpdateAsync(brand);

            UpdateBrandResponse response = _mapper.Map<UpdateBrandResponse>(brand);

           return response;
        }
    }
}