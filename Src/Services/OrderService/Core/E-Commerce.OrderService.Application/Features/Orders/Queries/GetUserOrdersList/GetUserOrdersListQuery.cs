using AutoMapper;
using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Application.Abstractions.Services;
using E_Commerce.OrderService.Application.Features.Orders.Models;
using E_Commerce.OrderService.Application.Models.Paging;
using E_Commerce.OrderService.Application.Models.ResponseModels;
using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.OrderService.Application.Features.Orders.Queries.GetUserOrdersList
{
    public class GetUserOrdersListQuery : PageRequest, IRequest<ResponseDto<UserOrderListModel>>
    {
        public required string UserName { get; set; }
        public class GetUserOrdersListQueryHandler : IRequestHandler<GetUserOrdersListQuery, ResponseDto<UserOrderListModel>>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IBuyerService _buyerService;
            private readonly IMapper _mapper;
            public GetUserOrdersListQueryHandler(IOrderRepository orderRepository, IBuyerService buyerService, IMapper mapper)
            {
                _orderRepository = orderRepository;
                _buyerService = buyerService;
                _mapper = mapper;
            }

            public async Task<ResponseDto<UserOrderListModel>> Handle(GetUserOrdersListQuery request, CancellationToken cancellationToken)
            {
                Guid Id = await _buyerService.FindBuyerIdWithUserName(request.UserName);

                //IQueryable<Order> value = await _orderRepository.GetListAsync(x => x.BuyerId == Id,
                //    orderBy: x => x.OrderByDescending(x => x.OrderDate),
                //    include: x => x.Include(x => x.OrderItems).Include(x => x.OrderStatus).Include(x => x.Buyer).ThenInclude(x => x.PaymentMethods),
                //    cancellationToken: cancellationToken);

                //var userOrderList = _mapper.ProjectTo<GetUserOrderList>(value);

                //var Orders = userOrderList.ToPaginate(request.Page, request.PageSize, 0);

                IPaginate<Order> Orders = await _orderRepository.GetListAsyncWithPaginate(x => x.BuyerId == Id,
                    orderBy: x => x.OrderByDescending(x => x.OrderDate),
                    include: x => x.Include(x => x.OrderItems).Include(x => x.OrderStatus).Include(x => x.Buyer).ThenInclude(x => x.PaymentMethods),
                    index: request.Page, size: request.PageSize,
                    cancellationToken: cancellationToken);

                return ResponseDto<UserOrderListModel>.SuccessWithData(_mapper.Map<UserOrderListModel>(Orders));
            }
        }
    }
}
