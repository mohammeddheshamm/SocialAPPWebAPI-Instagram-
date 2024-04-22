using Social.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; } //P => P.Name
        public Expression<Func<T, object>> OrderByDescending { get; set; }

        public BaseSpecification()
        {
            // This constructor is for getting objects without condition
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            //This constructor is to get a specific object from DB
        }

        public void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> OrderByDescendingExpression)
        {
            OrderByDescending = OrderByDescendingExpression;
        }
    }
}
