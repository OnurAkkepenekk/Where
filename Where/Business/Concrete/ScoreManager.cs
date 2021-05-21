using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
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
        public IResult Add(Score score)
        {
            _scoreDal.Add(score);
            return new SuccessResult(Messages.AddScore);
        }

        public IResult Delete(Score score)
        {
            _scoreDal.Delete(score);
            return new SuccessResult(Messages.DeleteScore);
        }

        public IDataResult<List<Score>> GetByLocationId(int placeId)
        {
            return new SuccessDataResult<List<Score>>(_scoreDal.GetAll(s => s.PlaceId == placeId), Messages.ScoreGetById);
        }

        public IResult Update(Score score)
        {
            _scoreDal.Update(score);
            return new SuccessResult(Messages.UpdateScore);
        }
    }
}
