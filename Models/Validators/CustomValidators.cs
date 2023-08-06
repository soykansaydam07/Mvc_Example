using FluentValidation;
using System.Collections.Generic;

namespace Mvc_Example.Models.Validators
{
    public static  class CustomValidators
    {
        public static IRuleBuilderOptions<T, List<TElement>> ListMustUpperThan<T, TElement>(this IRuleBuilder<T, List<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.Must(list => list.Count > num).WithMessage("Listede Yeterince elemean bulunmamaktadır.");
        }


        public static IRuleBuilderOptionsConditions<T, IList<TElement>> ListMustUpperSecond<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {

            return ruleBuilder.Custom((list, context) => {
                if (list.Count < num)
                {
                    context.AddFailure("Listede Yeterince elemean bulunmamaktadır(Second).");
                }
            });
        }
    }
}
