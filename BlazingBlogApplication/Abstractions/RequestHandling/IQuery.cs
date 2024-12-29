using BlazingBlogDomain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBlogApplication.Abstractions.RequestHandling
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
