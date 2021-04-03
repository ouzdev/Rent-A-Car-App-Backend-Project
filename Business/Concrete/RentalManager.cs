using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [CacheAspect(duration: 10)]
        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.RentalListed);
        }
        [CacheAspect(duration: 10)]
        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);
            return new SuccessDataResult<Rental>(result, Messages.RentListed);

        }
        [CacheAspect(duration: 10)]
        public IDataResult<List<GetRentalDetailDTO>> GetListRentalDetails()
        {
            var result = _rentalDal.GetRentalDetails();
            return new SuccessDataResult<List<GetRentalDetailDTO>>(result, Messages.GetListRentalDetail);
        }

        public IResult IsCarAvailable(int id)
        {
            var result = _rentalDal.IsCarAvailable(id);
            if (result)
            {
                return new SuccessResult(Messages.RentalCarAvailable);

            }
            return new ErrorResult(Messages.RentalCarNotAvailable);

        }
        [SecuredOperation("rental.add,administrator")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            if (IsCarAvailable(rental.CarId).Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalCarNotAvailable);

        }
        [SecuredOperation("rental.update,administrator")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        [SecuredOperation("rental.delete,administrator")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
    }
}
