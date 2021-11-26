using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
    public static class ResultExtensions
    {
        public static Result And(this Result result, Func<Result> otherFunc)
        {
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            return result;
        }

        public static Result<T> And<T>(this Result res, Func<Result<T>> otherFunc)
        {
            var result = res as Result<T> ?? new Result<T>(res.HttpStatusCode, res.ErrorMessages);
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success)
            {
                result.Data = r1.Data;
            }
            return result;
        }

        public static Result<T> And<T>(this Result<T> result, Func<Result> otherFunc)
        {
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            return result;
        }

        public static Result<T> And<T>(this Result<T> result, Func<Result<T>> otherFunc)
        {
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success)
            {
                result.Data = r1.Data;
            }
            return result;
        }

        public static Result<T> And<T>(this Result<T> res, Func<T, Result> otherFunc)
        {
            var result = res;
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc(result.Data);
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success
                && r1 is Result<T>)
            {
                result.Data = (r1 as Result<T>).Data;
            }
            return result;
        }

        public static Result AndExecute<T>(this Result<T> res, Func<T, Result> otherFunc)
        {
            var result = res;
            if (result.HasErrors)
            {
                return new Result
                {
                    HttpStatusCode = result.HttpStatusCode,
                    ErrorMessages = result.ErrorMessages
                };
            }
            return otherFunc(result.Data);
        }

        public static Result<TM> And<T, TM>(this Result<T> res, Func<T, Result<TM>> otherFunc)
        {
            var current = res;
            var result = res as Result<TM> ?? new Result<TM>(current.HttpStatusCode, current.ErrorMessages);
            if (result.Success)
            {
                result = result.And(() => otherFunc(current.Data));
            }
            return result;
        }

        public static Result<T> OnError<T>(this Result res, Func<Result<T>> otherFunc)
        {
            var result = res as Result<T> ?? new Result<T>(res.HttpStatusCode, res.ErrorMessages);
            if (result.Success)
            {
                return result;
            }
            return otherFunc();
        }

        public static Result OnError(this Result result, Func<Result> otherFunc)
        {
            if (result.Success)
            {
                return result;
            }
            return otherFunc();
        }

        public static Result<TM> Map<T, TM>(this Result<T> res, Func<T, TM> mappingFunc)
        {
            var result = res as Result<TM> ?? new Result<TM>(res.HttpStatusCode, res.ErrorMessages);
            if (result.Success)
            {
                result.Data = mappingFunc(res.Data);
            }
            return result;
        }

        public static async Task<Result<TM>> Map<T, TM>(this Task<Result<T>> res, Func<T, TM> mappingFunc)
        {
            var awaitedResult = await res;
            var result = awaitedResult as Result<TM> ?? new Result<TM>(awaitedResult.HttpStatusCode, awaitedResult.ErrorMessages);
            if (result.Success)
            {
                result.Data = mappingFunc(awaitedResult.Data);
            }
            return result;
        }

        public static async Task<Result<TM>> Map<T, TM>(this Task<Result<T>> res, Func<T, Task<TM>> mappingFunc)
        {
            var awaitedResult = await res;
            var result = awaitedResult as Result<TM> ?? new Result<TM>(awaitedResult.HttpStatusCode, awaitedResult.ErrorMessages);
            if (result.Success)
            {
                result.Data = await mappingFunc(awaitedResult.Data);
            }
            return result;
        }

        public static async Task<Result> And(this Result res, Func<Task<Result>> otherFunc)
        {
            if (res.HasErrors)
            {
                return res;
            }
            var r1 = await otherFunc();
            res.HttpStatusCode = r1.HttpStatusCode;
            res.ErrorMessages.AddRange(r1.ErrorMessages);
            return res;
        }

        public static async Task<Result<T>> And<T>(this Result res, Func<Task<Result<T>>> otherFunc)
        {
            var result = res as Result<T> ?? new Result<T>(res.HttpStatusCode, res.ErrorMessages);
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = await otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success)
            {
                result.Data = r1.Data;
            }
            return result;
        }

        public static async Task<Result<T>> And<T>(this Result<T> res, Func<T, Task<Result>> otherFunc)
        {
            if (res.Success)
            {
                return await res
                    .And(async result => await otherFunc(res.Data)
                        .And(() => Result.Ok(result))
                    );
            }
            return res;
        }

        public static async Task<Result> And(this Task<Result> res, Func<Task<Result>> otherFunc)
        {
            var result = await res;
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = await otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            return result;
        }

        public static async Task<Result> And(this Task<Result> res, Func<Result> otherFunc)
        {
            var result = await res;
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            return result;
        }

        public static async Task<Result<T>> And<T>(this Task<Result> res, Func<Task<Result<T>>> otherFunc)
        {
            var awaitedOpt = await res;
            var result = awaitedOpt as Result<T> ?? new Result<T>(awaitedOpt.HttpStatusCode, awaitedOpt.ErrorMessages);

            if (result.HasErrors)
            {
                return result;
            }
            var r1 = await otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success)
            {
                result.Data = r1.Data;
            }
            return result;
        }

        public static async Task<Result<T>> And<T>(this Task<Result> res, Func<Result<T>> otherFunc)
        {
            var awaitedOpt = await res;
            var result = awaitedOpt as Result<T> ?? new Result<T>(awaitedOpt.HttpStatusCode, awaitedOpt.ErrorMessages);

            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success)
            {
                result.Data = r1.Data;
            }
            return result;
        }

        public static async Task<Result<T>> And<T>(this Task<Result<T>> res, Func<T, Result> otherFunc)
        {
            var result = await res;
            if (result.HasErrors)
            {
                return result;
            }
            var r1 = otherFunc(result.Data);
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            return result;
        }

        public static async Task<Result<T>> And<T>(this Task<Result<T>> res, Func<Result> otherFunc)
        {
            var awaitedOpt = await res;
            if (awaitedOpt.HasErrors)
            {
                return awaitedOpt;
            }
            var r1 = otherFunc();
            awaitedOpt.HttpStatusCode = r1.HttpStatusCode;
            awaitedOpt.ErrorMessages.AddRange(r1.ErrorMessages);
            return awaitedOpt;
        }

        public static async Task<Result<T>> And<T>(this Task<Result<T>> res, Func<Task<Result>> otherFunc)
        {
            var awaitedOpt = await res;
            if (awaitedOpt.HasErrors)
            {
                return awaitedOpt;
            }
            var r1 = await otherFunc();
            awaitedOpt.HttpStatusCode = r1.HttpStatusCode;
            awaitedOpt.ErrorMessages.AddRange(r1.ErrorMessages);
            return awaitedOpt;
        }

        public static async Task<Result<T2>> And<T, T2>(this Task<Result<T>> res, Func<Task<Result<T2>>> otherFunc)
        {
            var awaitedOpt = await res;
            var result = awaitedOpt as Result<T2> ?? new Result<T2>(awaitedOpt.HttpStatusCode, awaitedOpt.ErrorMessages);

            if (result.HasErrors)
            {
                return result;
            }

            var r1 = await otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success)
            {
                result.Data = r1.Data;
            }
            return result;
        }

        public static async Task<Result<T2>> And<T, T2>(this Task<Result<T>> res, Func<Result<T2>> otherFunc)
        {
            var awaitedOpt = await res;
            var result = awaitedOpt as Result<T2> ?? new Result<T2>(awaitedOpt.HttpStatusCode, awaitedOpt.ErrorMessages);
            if (result.HasErrors)
            {
                return result;
            }

            var r1 = otherFunc();
            result.HttpStatusCode = r1.HttpStatusCode;
            result.ErrorMessages.AddRange(r1.ErrorMessages);
            if (r1.Success)
            {
                result.Data = r1.Data;
            }
            return result;
        }

        public static async Task<Result<TM>> And<T, TM>(this Task<Result<T>> res, Func<T, Task<Result<TM>>> otherFunc)
        {
            var awaitedOpt = await res;
            var result = awaitedOpt as Result<TM> ?? new Result<TM>(awaitedOpt.HttpStatusCode, awaitedOpt.ErrorMessages);
            if (result.Success)
            {
                result = await result.And(async () => await otherFunc(awaitedOpt.Data));
            }
            return result;
        }

        public static async Task<Result<TM>> And<T, TM>(this Result<T> res, Func<T, Task<Result<TM>>> otherFunc)
        {
            var current = res;
            var result = res as Result<TM> ?? new Result<TM>(current.HttpStatusCode, current.ErrorMessages);
            if (result.Success)
            {
                result = await result.And(async () => await otherFunc(current.Data));
            }
            return result;
        }

        public static async Task<Result<TM>> And<T, TM>(this Task<Result<T>> res, Func<T, Result<TM>> otherFunc)
        {
            var awaitedOpt = await res;
            var result = awaitedOpt as Result<TM> ?? new Result<TM>(awaitedOpt.HttpStatusCode, awaitedOpt.ErrorMessages);
            if (result.Success)
            {
                result = result.And(() => otherFunc(awaitedOpt.Data));
            }
            return result;
        }
    }
}

