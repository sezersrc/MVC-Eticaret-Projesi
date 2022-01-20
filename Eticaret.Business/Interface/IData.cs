using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eticaret.Business
{
    public interface IData<T>
    {
        List<T> List();
        List<T> List(Expression<Func<T, bool>> where);
        T Find(Expression<Func<T, bool>> where);
        int Insert(T data);
        int Update(T data);
        int Delete(T data);
        int Save();
    }
}