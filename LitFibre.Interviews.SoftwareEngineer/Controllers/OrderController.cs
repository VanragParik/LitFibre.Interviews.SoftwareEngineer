using LitFibre.Interviews.SoftwareEngineer.Models.Orders;
using LitFibre.Interviews.SoftwareEngineer.Services.DataProvider;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LitFibre.Interviews.SoftwareEngineer.Controllers
{
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        private OrderDataProvider _OrderDataProvider = new OrderDataProvider();

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        private ApiResponse GenerateResponse(string message, string code)
        {
            var response = new ApiResponse();
            response.Code = code;
            response.Message = message;
            response.IsSuccess = code == "200";
            return response;
        }

        [HttpGet]
        public ApiResponse ReadAllOrders()
        {
            var response = new ApiResponse();
            var data = _OrderDataProvider.GetAll();
            response = GenerateResponse("Success", "200");
            response.Data = data;
            return response;
        }

        [HttpGet]
        public ApiResponse ReadOrdersById(string id)
        {
            var response = new ApiResponse();
            if (!string.IsNullOrEmpty(id))
            {
                var data = _OrderDataProvider.Read(id);
                response = GenerateResponse("Success", "200");
                response.Data = data;
            }
            else
            {
                response = GenerateResponse("Please Insert Valid Id", "400");
            }
            return response;
        }

        [HttpPost]
        public ApiResponse AddNeworUpdateOrder(Order item)
        {
            var response = new ApiResponse();
            if (item != null && !string.IsNullOrEmpty(item.Id))
            {
                var alreadyExistItem = _OrderDataProvider.Read(item.Id);
                string messageText = !string.IsNullOrEmpty(alreadyExistItem.Id) ? "updated" : "inserted";
                _OrderDataProvider.Push(item);
                response = GenerateResponse($"Item with ID: {item.Id} {messageText} successfully", "200");
            }
            else
            {
                response = GenerateResponse("Please Insert Valid Order Item", "400");
            }

            return response;
        }

        [HttpPost]
        public ApiResponse DeleteOrder(string id)
        {
            var response = new ApiResponse();
            if (!string.IsNullOrEmpty(id))
            {
                _OrderDataProvider.Delete(id);
                response = GenerateResponse($"Item with ID: {id} deleted successfully", "200");
            }
            else
            {
                response = GenerateResponse("Please Insert Valid Id", "400");
            }
            return response;
        }

        [HttpGet]
        public ApiResponse ReadOrdersfromProductcode(string productCode)
        {
            var response = new ApiResponse();
            if (!string.IsNullOrEmpty(productCode))
            {
                Predicate<Order> predicate = o => o.ProductCodes.Contains(productCode);
                var data = _OrderDataProvider.Query(predicate);
                response = GenerateResponse("Success", "200");
                response.Data = data;
            }
            else
            {
                response = GenerateResponse("Please Insert Product Code", "400");
            }
            return response;
        }

        [HttpGet]
        public ApiResponse ReadOrdersPlacedAfterDate(string date)
        {
            var response = new ApiResponse();
            DateTime FormatedDate;
            string[] formats = {"dd/MM/yyyy","dd/MM/yyyy HH:mm","d/M/yyyy h:mm:ss tt", "d/M/yyyy h:mm tt",
                   "dd/MM/yyyy hh:mm:ss", "d/M/yyyy h:mm:ss",
                   "d/M/yyyy hh:mm tt", "d/M/yyyy hh tt",
                   "d/M/yyyy h:mm", "d/M/yyyy h:mm",
                   "dd/MM/yyyy hh:mm", "dd/M/yyyy hh:mm"};
            if (!string.IsNullOrEmpty(date) && DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out FormatedDate))
            {
                Predicate<Order> predicate = o => o.OrderDate > FormatedDate;
                var data = _OrderDataProvider.Query(predicate);
                response = GenerateResponse("Success", "200");
                response.Data = data;
            }
            else
            {
                response = GenerateResponse("Please Insert Valid Date", "400");
            }
            return response;
        }
    }
}
