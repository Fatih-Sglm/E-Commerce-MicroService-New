using AutoMapper;
using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Application.Features.Orders.Models;
using E_Commerce.OrderService.Application.Models.Paging;
using E_Commerce.OrderService.Application.Models.ResponseModels;
using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.OrderService.Application.Features.Orders.Queries.GetAllOrdersList
{
    public class GetAllOrdersQuery : PageRequest, IRequest<ResponseDto<AllOrdersListModel>>
    {
        public class GetAllOrdersQueryQueryHandler : IRequestHandler<GetAllOrdersQuery, ResponseDto<AllOrdersListModel>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            public GetAllOrdersQueryQueryHandler(IOrderRepository orderRepository, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _mapper = mapper;
            }
            public async Task<ResponseDto<AllOrdersListModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Order> Orders = await _orderRepository.GetListAsyncWithPaginate(
                    orderBy: x => x.OrderByDescending(x => x.OrderDate),
                    include: x => x.Include(x => x.OrderItems).Include(x => x.OrderStatus).Include(x => x.Buyer).ThenInclude(x => x.PaymentMethods),
                    index: request.Page, size: request.PageSize,
                    cancellationToken: cancellationToken);

                return ResponseDto<AllOrdersListModel>.SuccessWithData(_mapper.Map<AllOrdersListModel>(Orders));
            }
        }
    }
}
