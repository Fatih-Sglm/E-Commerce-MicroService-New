namespace E_Commerce.OrderService.Application.Models.ResponseModels
{
    public class ResponseDto<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }

        public static ResponseDto<T> SuccessWithData(T data)
        {
            return new ResponseDto<T> { Data = data };
        }

        public static ResponseDto<T> SuccessWithOutData(string message)
        {
            return new ResponseDto<T> { Message = message };
        }
    }
}
