using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IPictureDal _pictureDal;
        public ProductManager(IProductDal productDal,IPictureDal pictureDal)
        {
            _productDal = productDal;
            _pictureDal = pictureDal;
        }
        public IResult Add(ProductDto productDto)
        {
            try
            {
                productDto.Product.Code = $"{productDto.Product.CategoryId}{productDto.GetHashCode()}";
                _productDal.Add(productDto.Product);
                foreach (var picture in productDto.Pictures)
                {
                    picture.ProductCode = productDto.Product.Code;
                    _pictureDal.Add(picture);
                }
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception )
            {

                return new ErrorResult(Messages.ProductNotAdded);
            }
        }

        public IResult Delete(ProductDto productDto)
        {
            try
            {
                _productDal.Delete(productDto.Product);
                foreach (var picture in productDto.Pictures)
                {
                    _pictureDal.Delete(picture);
                }
                return new SuccessResult(Messages.ProductDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ProductNotDeleted);
            }
        }

        public IDataResult<ProductDto> GetById(int id)
        {
            try
            {
                var product = _productDal.Get(p=>p.Id == id);
                var pictures = _pictureDal.GetList(pic => pic.ProductCode == product.Code).ToList();
                ProductDto data = new ProductDto
                {
                    Product = product,
                    Pictures = pictures,
                };
                return new SuccessDataResult<ProductDto>(data);
            }
            catch (Exception)
            {

                return new ErrorDataResult<ProductDto>(Messages.ProductNotGet);
            }
        }

        
        public IDataResult<List<ProductDto>> GetList()
        {
            try
            {
                List<ProductDto> data = new List<ProductDto>();

                var products = _productDal.GetList().ToList();
                foreach (var product in products)
                {
                    var pictures =_pictureDal.GetList(pic => pic.ProductCode == product.Code).ToList();
                    data.Add(new ProductDto { Product = product, Pictures = pictures });
                };
                return new SuccessDataResult<List<ProductDto>>(data);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<ProductDto>>(Messages.ProductsNotGet);
            }
        }

        public IDataResult<List<ProductDto>> GetListByCategoryId(int categoryId)
        {
            try
            {
                List<ProductDto> data = new List<ProductDto>();

                var products = _productDal.GetList(p=>p.CategoryId == categoryId).ToList();
                foreach (var product in products)
                {
                    var pictures = _pictureDal.GetList(pic => pic.ProductCode == product.Code).ToList();
                    data.Add(new ProductDto { Product = product, Pictures = pictures });
                };
                return new SuccessDataResult<List<ProductDto>>(data);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<ProductDto>>(Messages.ProductsNotGet);
            }
        }

        public IResult Update(ProductDto productDto)
        {
            try
            {
                _productDal.Update(productDto.Product);
                foreach (var picture in productDto.Pictures)
                {
                    _pictureDal.Update(picture);
                }
                return new SuccessResult(Messages.ProductUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.ProductNotUpdated);
            }
        }
    }
}
