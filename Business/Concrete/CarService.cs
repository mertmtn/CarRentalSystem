using Business.Abstract;
using Business.Constants.Messages;
using Business.Constants.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic; 

namespace Business.Concrete
{
    public class CarService : ICarService
    {
        ICarDal _carDal;
        public CarService(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        { 
            if (car.DailyPrice > 0 && (!string.IsNullOrEmpty(car.Name) && car.Name.Length >= 2))
            {
                _carDal.Add(car);                
            }
            else
            {
                //TODO:Fluent validation ile düzenlenecek
                if (!(car.DailyPrice > 0))
                {
                    return new ErrorResult(CarValidationMessage.CarInValidDailyPrice);                    
                }

                if (string.IsNullOrEmpty(car.Name) || car.Name.Length < 2)
                {
                    return new ErrorResult(CarValidationMessage.CarInValidName);                   
                }
            }
            return new SuccessResult(CarMessage.CarAddedSuccessfully);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarMessage.CarDeletedSuccessfully);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }       

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0 && (!string.IsNullOrEmpty(car.Name) && car.Name.Length >= 2))
            {
                _carDal.Update(car);
            }
            else
            {
                //TODO:Fluent validation ile düzenlenecek
                if (!(car.DailyPrice > 0))
                {
                    return new ErrorResult(CarValidationMessage.CarInValidDailyPrice);
                }

                if (string.IsNullOrEmpty(car.Name) || car.Name.Length < 2)
                {
                    return new ErrorResult(CarValidationMessage.CarInValidName);
                }
            }            
            return new SuccessResult(CarMessage.CarUpdatedSuccessfully);
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails());
        }
    }
}
