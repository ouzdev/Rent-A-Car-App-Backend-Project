using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal ColorDal)
        {
            _colorDal = ColorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color Color)
        {
            _colorDal.Add(Color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color Color)
        {
            _colorDal.Delete(Color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }

        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(x => x.Id == id);
            return new SuccessDataResult<Color>(result);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color Color)
        {
            _colorDal.Update(Color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
