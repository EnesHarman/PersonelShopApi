using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Mail.Abstract;
using Core.Utilities.Mail.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {

        IOrderDal _orderDal;
        IPictureDal _pictureDal;
        IMailService _mailService; 

        public OrderManager(IOrderDal orderDal,  IPictureDal pictureDal, IMailService mailService)
        {
            _orderDal = orderDal;
            _pictureDal = pictureDal;
            _mailService = mailService;
        }
        public IResult Add(Order order)
        {
            try
            {
                _orderDal.Add(order);
                return new SuccessResult(Messages.OrderAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.OrderNotAdded);
            }
        }

        public IResult Delete(Order order)
        {
            try
            {
                Order orderToDelete = _orderDal.Get(ord => ord.ProductId == order.ProductId && ord.UserID == order.UserID);
                _orderDal.Delete(orderToDelete);
                return new SuccessResult(Messages.OrderDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.OrderNotDeleted);
            }
        }

        public async Task< IResult> Execute(User user, List<ProductDto> orders)
        {
            MailContent mailContent = new MailContent();
            mailContent.Subject = "Someone has ordered somethings";

            mailContent.Body = $"{user.Name} {user.SurName} has ordered: \n";
            foreach (var order in orders)
            {
                mailContent.Body += $"{order.Product.Name}--";
            }
            mailContent.Body += $"The address is {user.Adress} \nNumber is {user.PhoneNum}";

            List<Order> userOrders = _orderDal.GetList(or => or.UserID == user.Id).ToList();

            foreach (var order in userOrders)
            {
                _orderDal.Delete(order);
            }

            try
            {
                await _mailService.SendEmailAsync(mailContent);
                return new SuccessResult(Messages.OrdersExecuted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.OrderCantExecute);
            }
            
        }

        public IDataResult<List<ProductDto>> GetOrders(int userId)
        {
            try
            {
                List<ProductDto> data = new List<ProductDto>();

                var products = _orderDal.GetOrders(userId);

                foreach (var product in products)
                {
                    var pictures = _pictureDal.GetList(pic => pic.ProductCode == product.Code).ToList();
                    data.Add(new ProductDto { Product = product, Pictures = pictures });
                }
                

                return new SuccessDataResult<List<ProductDto>>(data);
            }
            catch (Exception)
            {
                return new ErrorDataResult<List<ProductDto>>(Messages.OrdersNotListed);
            }
        }
    }
}
