using HRMSapplication.Login;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.Login
{
    public record LoginCommand(string Email, string Password):IRequest<LoginResponse>;

}
