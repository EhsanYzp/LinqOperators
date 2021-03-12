
using System;

namespace LinqOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqComponent lc = new LinqComponent();
            
            //LINQ Operators Tests
            lc.QuerySyntax();
            lc.MethodSyntax();
            lc.WhereOperator();
            lc.OfTypeOperator();
            lc.OrderByOperator();
            lc.ThenByOperator();
            lc.GroupByOperator();
            lc.ToLookUpOperator();
            lc.JoinOperator();
            lc.GroupJoinOperator();
            lc.SelectOperator();
            lc.AllOperator();
            lc.AnyOperator();
            lc.ContainsOperator();
            lc.AggegateOperator();
            lc.AverageOperator();
            lc.CountOperator();
            lc.MaxOperator();
            lc.SumOperator();
            lc.ElementAtOperator();
            lc.ElementAtOrDefaultOperator();
            lc.FirstOperator();
            lc.FirstOrDefaultOperator();
            lc.LastOperator();
            lc.LastOrDefaultOperator();
            lc.SingleOperator();
            lc.SingleOrDefaultOperator();
            lc.SequenceEqualOperator();
            lc.ConcatOperator();
            lc.DefaultIfEmptyOperator();
            lc.EmptyOperator();
            lc.RangeOperator();
            lc.RepeatOperator();
            lc.DistinctOperator();
            lc.ExceptOperator();
            lc.IntersectOperator();
            lc.UnionOperator();
            lc.SkipOperator();
            lc.SkipWhileOperator();
            lc.TakeOperator();
            lc.TakeWhileOperator();
            lc.ToListAndToArrayOperators();
            lc.ToDictionaryOperator();

            Console.ReadKey();

        }
    }
}
