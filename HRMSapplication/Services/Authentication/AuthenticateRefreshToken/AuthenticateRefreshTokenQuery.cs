using AutoMapper;
using HRMS.Application.AuthenticateRefreshToken;
using HRMSapplication.Response;
using MediatR;

namespace HRMS.Application.Queries.AuthenticateRefreshToken
{
    public record AuthenticateRefreshTokenQuery(string RefreshToken):IRequest<AuthenticateRefreshTokenResponse>;
}
