using Business.Abstract;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator), Priority = 1)]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCountByCarId(carImage.CarId,5));

            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(CarImageMessage.CarImageAddedSuccessfully);
        }

        private IResult CheckCarImageCountByCarId(int carId, int imageLimit)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
             
            if (result.Count== imageLimit)
            {
                return new ErrorResult(CarImageMessage.CarImageLimitExceeded(imageLimit));
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageMessage.CarImageDeletedSuccessfully);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            var result= _carImageDal.Get(c=>c.Id== carImageId);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(CarImageMessage.CarImageUpdatedSuccessfully);
        }
    }
}
