using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
        [CacheAspect(duration: 10)]
        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }
        [CacheAspect(duration: 10)]

        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(x => x.Id == id);
            return new SuccessDataResult<Color>(result);
        }
        [SecuredOperation("color.update,administrator")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color Color)
        {
            _colorDal.Update(Color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        [SecuredOperation("color.delete,administrator")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color Color)
        {
            _colorDal.Add(Color);
            return new SuccessResult(Messages.ColorAdded);
        }
        [SecuredOperation("color.delete,administrator")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color Color)
        {
            _colorDal.Delete(Color);
            return new SuccessResult(Messages.ColorDeleted);
        }
    }
}
