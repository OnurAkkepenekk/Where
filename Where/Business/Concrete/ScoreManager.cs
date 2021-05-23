using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ScoreManager : IScoreService
    {
        IScoreDal _scoreDal;
        public ScoreManager(IScoreDal scoreDal)
        {
            _scoreDal = scoreDal;
        }
        [SecuredOperation("score.add")]
        [ValidationAspect(typeof(ScoreValidator))]
        [CacheRemoveAspect("IScoreService.Get")]
        public IResult Add(Score score)
        {
            _scoreDal.Add(score);
            return new SuccessResult(Messages.AddScore);
        }

        [SecuredOperation("score.add,admin")]
        [CacheRemoveAspect("IScoreService.Get")]
        public IResult Delete(Score score)
        {
            _scoreDal.Delete(score);
            return new SuccessResult(Messages.DeleteScore);
        }
        [CacheAspect]
        public IDataResult<List<Score>> GetByLocationId(int placeId)
        {
            return new SuccessDataResult<List<Score>>(_scoreDal.GetAll(s => s.PlaceId == placeId), Messages.ScoreGetById);
        }
        [ValidationAspect(typeof(ScoreValidator))]
        [CacheRemoveAspect("IScoreService.Get")]
        public IResult Update(Score score)
        {
            _scoreDal.Update(score);
            return new SuccessResult(Messages.UpdateScore);
        }
    }
}
