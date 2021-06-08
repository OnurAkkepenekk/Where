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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        [ValidationAspect(typeof(CommentValidator))]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.AddComment);
        }
        [SecuredOperation("comment.delete,admin")]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.DeleteComment);
        }
        [CacheAspect]
        public IDataResult<List<Comment>> GetByLocationId(string placeId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(c => c.PlaceId == placeId), Messages.CommentGetById);
        }
        [ValidationAspect(typeof(CommentValidator))]
        [CacheRemoveAspect("ICommentService.Get")]
        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.UpdateComment);
        }
    }
}
