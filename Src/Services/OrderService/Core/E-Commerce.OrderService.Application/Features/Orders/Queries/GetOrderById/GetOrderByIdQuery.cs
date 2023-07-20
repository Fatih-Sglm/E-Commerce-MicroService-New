using AutoMapper;
using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Application.Features.Orders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.OrderService.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDetailModel>
    {
        public Guid OrderId { get; set; }

        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDetailModel>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

            public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }

            public async Task<OrderDetailModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetAsync(x => x.Id == request.OrderId,
                    c => c.Include(x => x.OrderItems).Include(x => x.OrderStatus),
                    cancellationToken: cancellationToken);

                return _mapper.Map<OrderDetailModel>(order);
            }
        }
    }
}
