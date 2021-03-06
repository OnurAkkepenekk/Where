using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IScoreService
    {
        IResult Add(Score score);
        IResult Delete(Score score);
        IResult Update(Score score);
        IDataResult<List<Score>> GetByLocationId(string locationId);
    }
}
