using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebStore.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _Next;
        public TestMiddleware(RequestDelegate Next)
        {
            _Next = Next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Действие до следующего узла в конвейере

            // context.Request. ... context.Response. ...

            var next = _Next(context);

            // Действие во время которого оставшаяся часть конвейера что-то делает в контекстом

            await next; // Точка синхронизации, can put try-catch around to work with exceptions

            // Действие по завершению работы оставшейся части конвейера
        }
    }
}
